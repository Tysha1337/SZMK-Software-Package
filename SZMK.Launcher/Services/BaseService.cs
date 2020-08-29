using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Launcher.Services
{
    public class BaseService
    {
        private readonly string Path = Directory.GetCurrentDirectory() + @"\Updater\Settings\connect.conf";

        private string _Port;
        private string _Server;

        public BaseService()
        {
            if (!GetParametersConnect())
            {
                throw new Exception("Ошибка получения данных для подключения к серверу обновления");
            }
        }

        private bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(Path))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(Path, FileMode.Open)))
                {
                    _Server = sr.ReadLine();
                    _Port = sr.ReadLine();
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        protected bool CheckConnect()
        {
            try
            {
                TcpClient tcpClient = new TcpClient();

                var result = tcpClient.BeginConnect(_Server, Convert.ToInt32(_Port), null, null);

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
        protected string Server
        {
            get
            {
                return _Server;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Server = value;
                }
            }
        }

        protected string Port
        {
            get
            {
                return _Port;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Port = value;
                }
            }
        }
    }
}
