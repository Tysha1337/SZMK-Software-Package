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
        TcpListener listener;

        static int CountClients = 0;

        private bool working;
        private string Port;

        private string LastVersion;

        private OperationsFiles operationsFiles;
        private OperationsVersions versions;

        public Server(OperationsFiles operationsFiles, OperationsVersions versions)
        {
            try
            {
                GetParametersConnect();

                this.operationsFiles = operationsFiles;
                this.versions = versions;
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
                working = false;
                listener.Stop();

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
                        using (BinaryReader reader = new BinaryReader(inputStream))
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
            catch
            {
                ListeningAsync();
            }
        }
        private void CheckedUpdate(BinaryReader reader, NetworkStream stream)
        {
            try
            {
                string ClientHost = reader.ReadString();//Наименование компа который попросил обновление

                string ClientVersion = reader.ReadString();

                int ClientFilesCount = reader.ReadInt32();

                List<LastUpdateFiles> ClientFiles = new List<LastUpdateFiles>();

                for (int i = 0; i < ClientFilesCount; i++)
                {
                    ClientFiles.Add(new LastUpdateFiles { FileName = reader.ReadString(), Hash = reader.ReadString(), NeedUpdate = true });
                }

                List<FileAndMove> UpdatesFiles = CompareFiles(ClientFiles);
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    if (UpdatesFiles.Count != 0)
                    {
                        writer.Write(true);

                        writer.Write(UpdatesFiles.Count);

                        for (int i = 0; i < UpdatesFiles.Count; i++)
                        {
                            writer.Write(UpdatesFiles[i].FileName);
                            writer.Write(UpdatesFiles[i].Move);
                        }
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
        private List<FileAndMove> CompareFiles(List<LastUpdateFiles> ClientFiles)
        {
            try
            {
                List<LastUpdateFiles> ServerFiles = operationsFiles.GetSettingsUpdate();

                List<FileAndMove> UpdateFiles = new List<FileAndMove>();

                for (int i = 0; i < ClientFiles.Count; i++)
                {
                    List<LastUpdateFiles> compares = ServerFiles.Where(p => p.FileName == ClientFiles[i].FileName).ToList();

                    if (compares.Count == 1)
                    {
                        if (!(compares[0].Hash == ClientFiles[i].Hash) && compares[0].NeedUpdate)
                        {
                            UpdateFiles.Add(new FileAndMove { FileName = ClientFiles[i].FileName, Move = "Update" });
                        }
                    }
                    else
                    {
                        UpdateFiles.Add(new FileAndMove { FileName = ClientFiles[i].FileName, Move = "Remove" });
                    }
                }

                for (int i = 0; i < ServerFiles.Count; i++)
                {
                    List<LastUpdateFiles> compares = ClientFiles.FindAll(p => p.FileName == ServerFiles[i].FileName);

                    if (compares.Count == 0 && ServerFiles[i].NeedUpdate)
                    {
                        UpdateFiles.Add(new FileAndMove { FileName = ServerFiles[i].FileName, Move = "Add" });
                    }
                }

                return UpdateFiles;
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
                LastVersion = versions.GetLastVersion();

                int CountFiles = reader.ReadInt32();

                for (int i = 0; i < CountFiles; i++)
                {
                    string FileName = reader.ReadString();

                    using (FileStream inputStream = File.OpenRead(@"Versions\" + LastVersion + @"\" + FileName))
                    {
                        long lenght = inputStream.Length;

                        BinaryWriter writer = new BinaryWriter(stream);
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
    }
}
