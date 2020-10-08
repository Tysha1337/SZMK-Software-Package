using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SZMK.Desktop.Services.Setting
{
    public class User
    {
        private String _ArchivePath;
        private Int32 _TypeScan;
        private Boolean _Hidden;

        public User()
        {
            if (!GetParametersConnect())
            {
                throw new Exception("Ошибка при получении пользовательских путей приложения");
            }
        }

        public bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.UserArhivePath))
                {
                    throw new Exception();
                }

                if (!File.Exists(SystemArgs.Path.UserSettingsPath))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(SystemArgs.Path.UserArhivePath, FileMode.Open)))
                {
                    _ArchivePath = sr.ReadLine();
                }

                XDocument parameters = XDocument.Load(SystemArgs.Path.UserSettingsPath);

                _TypeScan = Convert.ToInt32(parameters.Element("Program").Element("TypeScan").Value);

                string hidden = parameters.Element("Program").Element("Hidden").Value;

                if (hidden.ToLower() != "true")
                {
                    _Hidden = false;
                }
                else
                {
                    _Hidden = true;
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
                using (StreamWriter sw = new StreamWriter(File.Open(SystemArgs.Path.UserArhivePath, FileMode.Create)))
                {
                    sw.WriteLine(_ArchivePath);
                }

                XDocument parameters = XDocument.Load(SystemArgs.Path.UserSettingsPath);

                parameters.Element("Program").Element("TypeScan").SetValue(_TypeScan);
                parameters.Element("Program").Element("Hidden").SetValue(_Hidden);

                parameters.Save(SystemArgs.Path.UserSettingsPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckFile()
        {
            if (!Directory.Exists(_ArchivePath))
            {
                return false;
            }

            return true;
        }

        public String ArchivePath
        {
            get
            {
                return _ArchivePath;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _ArchivePath = value;
                }
            }
        }

        public Int32 TypeScan
        {
            get
            {
                return _TypeScan;
            }
            set
            {
                _TypeScan = value;
            }
        }
        public Boolean Hidden
        {
            get
            {
                return _Hidden;
            }
            set
            {
                _Hidden = value;
            }
        }
    }
}
