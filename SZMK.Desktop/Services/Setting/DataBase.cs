using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services.Setting
{
    public class DataBase
    {
        private String _Name;
        private String _Owner;
        private String _Port;
        private String _IP;
        private String _Password;

        public DataBase()
        {
            if (CheckFile())
            {
                if(!GetParametersConnect())
                {
                    throw new Exception("Ошибка при получении параметров подключения к базе данных");
                }
            }
            else
            {
                throw new Exception("Файл подключения к базе данных не найден");
            }

            CheckParameters();
        }

        public String Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    _Name = value;
                    SetParametersConnect();
                }
            }
        }

        public String Owner
        {
            get
            {
                return _Owner;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Owner = value;
                    SetParametersConnect();
                }
            }
        }

        public String Port
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
                    SetParametersConnect();
                }
            }
        }

        public String IP
        {
            get
            {
                return _IP;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _IP = value;
                    SetParametersConnect();
                }
            }
        }

        public String Password
        {
            get
            {
                return _Password;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Password = value;
                    SetParametersConnect();
                }
            }
        }

        public void CheckParameters()
        {
            if(String.IsNullOrEmpty(_Name) || _Name.Trim() != "SZMK")
            {
                throw new Exception("Недействительное наименование базы данных");
            }

            if (String.IsNullOrEmpty(_Owner) || _Owner.Trim() != "postgres")
            {
                throw new Exception("Недействительный владелец базы данных");
            }

            if (String.IsNullOrEmpty(_IP))
            {
                throw new Exception("Недействительный адрес базы данных");
            }

            if (String.IsNullOrEmpty(_Port))
            {
                throw new Exception("Недействительный порт базы данных");
            }

            if (String.IsNullOrEmpty(_Password))
            {
                throw new Exception("Недействительный пароль базы данных");
            }
        }

        public bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.MainConnectDBPath))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(SystemArgs.Path.MainConnectDBPath, FileMode.Open)))
                {
                    _Name = sr.ReadLine();
                    _Owner = sr.ReadLine();
                    _IP = sr.ReadLine();
                    _Port = sr.ReadLine();
                    _Password = Encryption.DecryptRSA(sr.ReadLine());
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

         

        public bool SetParametersConnect()
        {
            try
            {
                String Dir = SystemArgs.Path.GetDirectory(SystemArgs.Path.MainConnectDBPath);

                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }

                using (StreamWriter sw = new StreamWriter(File.Open(SystemArgs.Path.MainConnectDBPath, FileMode.Create)))
                {
                    sw.WriteLine(_Name);
                    sw.WriteLine(_Owner);
                    sw.WriteLine(_IP);
                    sw.WriteLine(_Port);
                    sw.WriteLine(Encryption.EncryptRSA(_Password));
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckFile()
        {
            if (!File.Exists(SystemArgs.Path.MainConnectDBPath))
            {
                return false;
            }

            return true;
        }

        public bool CheckConnect(String ConnectString)
        {
            return SystemArgs.Request.CheckConnect(ConnectString);
        }

        public override string ToString()
        {
            return $@"Server = {_IP}; Port = {_Port}; User Id = {_Owner}; Password = {_Password}; Database = {_Name};";
        }
    }
}
