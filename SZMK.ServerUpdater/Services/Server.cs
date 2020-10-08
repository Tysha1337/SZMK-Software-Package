using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.ServerUpdater.Models;

namespace SZMK.ServerUpdater.Services
{
    class Server
    {
        private readonly Logger logger;

        TcpListener listener;

        static int CountClients = 0;

        private bool working;
        private string Port;

        private OperationsFiles OperationsFiles;
        private OperationsVersions OperationsVersions;

        public Server(OperationsFiles OperationsFiles, OperationsVersions OperationsVersions)
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                GetParametersConnect();

                this.OperationsFiles = OperationsFiles;
                this.OperationsVersions = OperationsVersions;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool Start()
        {
            try
            {
                working = true;
                listener = new TcpListener(IPAddress.Any, Convert.ToInt32(Port));
                listener.Start();
                ListeningAsync();

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool Stop()
        {
            try
            {
                if (CountClients <= 0)
                {
                    working = false;
                    listener.Stop();
                }
                else
                {
                    throw new Exception("Невозможно остановить сервер, имеются подключенные клиенты");
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private async void ListeningAsync()
        {
            await Task.Run(() => Listening());
        }
        private void Listening()
        {
            try
            {
                while (working)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    CountClients++;
                    using (NetworkStream inputStream = client.GetStream())
                    {
                        using (BinaryReader reader = new BinaryReader(inputStream, Encoding.UTF8))
                        {
                            if (!reader.ReadBoolean())
                            {
                                if (!reader.ReadBoolean())
                                {
                                    CheckedUpdate(reader, inputStream);
                                }
                                else
                                {
                                    Update(reader, inputStream, client);
                                }
                            }
                        }
                    }
                    client.Close();
                    CountClients--;
                }
            }
            catch (Exception Ex)
            {
                CountClients--;

                logger.Error(Ex.ToString());

                ListeningAsync();
            }
        }
        private void CheckedUpdate(BinaryReader reader, NetworkStream stream)
        {
            try
            {
                string ClientProduct = reader.ReadString();

                string ClientHost = reader.ReadString();

                string ClientVersion = reader.ReadString();

                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    if (ClientVersion != OperationsVersions.GetLastVersion(ClientProduct))
                    {
                        writer.Write(true);
                    }
                    else
                    {
                        writer.Write(false);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void Update(BinaryReader reader, NetworkStream stream, TcpClient client)
        {
            try
            {
                string ClientProduct = reader.ReadString();

                string ClientHost = reader.ReadString();

                string ClientVersion = reader.ReadString();

                List<FileAndMove> files = OperationsFiles.GetLastFiles(ClientVersion, OperationsVersions.GetLastVersion(ClientProduct), ClientProduct);

                GenerateInfoUpdate(ClientProduct, ClientHost, files);

                using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8))
                {
                    using (FileStream inputStream = File.OpenRead($@"About\{ClientProduct}\{ClientHost}\InfoUpdate.conf"))
                    {
                        long lenght = inputStream.Length;

                        writer.Write(lenght);

                        long totalBytes = 0;
                        int readBytes = 0;
                        byte[] buffer = new byte[8192];

                        do
                        {
                            readBytes = inputStream.Read(buffer, 0, buffer.Length);
                            stream.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        } while (client.Connected && totalBytes < lenght);
                    }

                    Directory.Delete($@"About\{ClientProduct}\{ClientHost}", true);

                    var noremovefiles = files.FindAll(p => p.Move != "Remove");

                    if (reader.ReadBoolean())
                    {
                        writer.Write(noremovefiles.Count);

                        if (reader.ReadBoolean())
                        {
                            for (int i = 0; i < noremovefiles.Count; i++)
                            {
                                writer.Write(noremovefiles[i].FileName);

                                using (FileStream inputStream = File.OpenRead($@"Products\{ClientProduct}\{OperationsVersions.GetLastVersion(ClientProduct)}\{noremovefiles[i].FileName}"))
                                {
                                    long lenght = inputStream.Length;

                                    writer.Write(lenght);

                                    long totalBytes = 0;
                                    int readBytes = 0;
                                    byte[] buffer = new byte[8192];

                                    do
                                    {
                                        readBytes = inputStream.Read(buffer, 0, buffer.Length);
                                        stream.Write(buffer, 0, readBytes);
                                        totalBytes += readBytes;
                                    } while (client.Connected && totalBytes < lenght);

                                    if (reader.ReadInt32() != i)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void GetParametersConnect()
        {
            try
            {
                if (!File.Exists(@"Program\Settings\Connect\connect.conf"))
                {
                    throw new Exception("Файл данных сервера не найден");
                }

                XDocument doc = XDocument.Load(@"Program\Settings\Connect\connect.conf");

                Port = doc.Element("Connect").Element("Port").Value;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void GenerateInfoUpdate(string Product, string Host, List<FileAndMove> files)
        {
            try
            {
                XDocument infoupdate = new XDocument();
                XElement program = new XElement("Program");

                foreach (var file in files)
                {
                    XElement f = new XElement("File");

                    XElement fileName = new XElement("FileName", file.FileName);
                    f.Add(fileName);
                    XElement move = new XElement("Move", file.Move);
                    f.Add(move);

                    program.Add(f);
                }
                infoupdate.Add(program);

                Directory.CreateDirectory($@"About\{Product}\{Host}");

                infoupdate.Save($@"About\{Product}\{Host}\InfoUpdate.conf");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool GetStatus()
        {
            try
            {
                return working;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
