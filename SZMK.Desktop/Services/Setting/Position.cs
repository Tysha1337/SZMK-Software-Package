using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SZMK.Desktop.Services.Setting
{
    public class Position
    {
        private Boolean _SelectedUser;
        public Position()
        {
            if (!GetParametersConnect())
            {
                throw new Exception("Ошибка при получении путей настроек должностей приложения");
            }
        }

        public bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.KBSettingsPath))
                {
                    throw new Exception();
                }

                XDocument parameters = XDocument.Load(SystemArgs.Path.KBSettingsPath);

                string selectedUser = parameters.Element("Program").Element("SelectedUser").Value;

                if (selectedUser.ToLower() != "true")
                {
                    _SelectedUser = false;
                }
                else
                {
                    _SelectedUser = true;
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
                XDocument parameters = XDocument.Load(SystemArgs.Path.KBSettingsPath);

                parameters.Element("Program").Element("SelectedUser").SetValue(_SelectedUser);

                parameters.Save(SystemArgs.Path.KBSettingsPath);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean SelectedUser
        {
            get
            {
                return _SelectedUser;
            }
            set
            {
                _SelectedUser = value;
            }
        }
    }
}
