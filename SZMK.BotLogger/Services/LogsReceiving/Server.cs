using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using SZMK.BotLogger.Services.Settings;

namespace SZMK.BotLogger.Services.LogsReceiving
{
    class Server
    {
        static TcpListener listener;
        bool flag = true;
        public bool Start()
        {
            try
            {
                XDocument server = XDocument.Load(PathProgram.Server);

                listener = new TcpListener(IPAddress.Any, Convert.ToInt32(server.Element("Settings").Element("Port").Value));
                listener.Start();
                ListeningAsync();
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
                while (flag)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    using (NetworkStream inputStream = client.GetStream())
                    {
                        using (BinaryReader reader = new BinaryReader(inputStream))
                        {
                            if (reader.ReadString() == "Logs")
                            {
                                string Product = reader.ReadString();
                                string WorkStation = reader.ReadString();
                                string Type = reader.ReadString();
                                string Message = reader.ReadString();

                                SaveLogs(Product, WorkStation, Type, Message);
                            }
                        }
                    }
                    client.Close();
                }
            }
            catch (Exception Ex)
            {
                ListeningAsync();
            }
        }
        private void SaveLogs(string Product, string Workstation, string Type, string Message)
        {
            try
            {
                string DirectoryPath = @"Products\" + Product;
                string FilePath = $@"Products\{Product}\{DateTime.Now.ToShortDateString()}.log";
                string Log = $@"{DateTime.Now} : {Workstation} : {Type} : {Message}";

                if (Directory.Exists(DirectoryPath))
                {
                    if (!File.Exists(FilePath))
                    {
                        File.Create(FilePath).Close();
                    }

                    using (StreamWriter sw = new StreamWriter(FilePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(Log);
                    }
                }
                else
                {
                    //log exception
                }

            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool Stop()
        {
            try
            {
                flag = false;
                listener.Stop();

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
