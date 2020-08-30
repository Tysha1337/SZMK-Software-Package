using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.LauncherUpdater
{
    public class BaseProgram
    {
        private readonly static string Path = Directory.GetCurrentDirectory() + @"\Settings\connect.conf";

        public static string Port;
        public static string Server;

        protected static bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(Path))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(Path, FileMode.Open)))
                {
                    Server = sr.ReadLine();
                    Port = sr.ReadLine();
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        protected static bool CheckConnect()
        {
            try
            {
                TcpClient tcpClient = new TcpClient();

                var result = tcpClient.BeginConnect(Server, Convert.ToInt32(Port), null, null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                if (!success)
                {
                    throw new Exception();
                }

                NetworkStream outputStream = tcpClient.GetStream();
                BinaryWriter writer = new BinaryWriter(outputStream);
                writer.Write(true);
                tcpClient.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
