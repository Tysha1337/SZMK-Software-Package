using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services.Setting
{
    public class MobileApplication
    {
        String _Port;

        public MobileApplication()
        {
            if(!GetParametersConnect())
            {
                throw new Exception("Ошибка при получении параметров подключения к мобильному приложению");
            }
        }

        public bool GetParametersConnect()
        {
            try
            {
                if(!File.Exists(SystemArgs.Path.MainConnectMobilePath))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(SystemArgs.Path.MainConnectMobilePath, FileMode.Open)))
                {
                    _Port = sr.ReadLine();
                }

                return true;
            }
            catch(Exception)
            {
                return false;  
            }
        }

        public bool SetParametersConnect()
        {
            try
            {
                String Dir = SystemArgs.Path.GetDirectory(SystemArgs.Path.MainConnectMobilePath);

                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }

                using (StreamWriter sw = new StreamWriter(File.Open(SystemArgs.Path.MainConnectMobilePath, FileMode.Create)))
                {
                    sw.WriteLine(_Port);
                }

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool CheckFile()
        {
            if (!File.Exists(SystemArgs.Path.MainConnectMobilePath))
            {
                return false;
            }

            return true;
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
                }
            }
        }
    }
}
