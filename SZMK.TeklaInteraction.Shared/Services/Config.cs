using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.TeklaInteraction.Shared.Services.Interfaces;

namespace SZMK.TeklaInteraction.Shared.Services
{
    public class Config : IConfig
    {
        private bool _CheckMark;
        public Config()
        {
            if (!GetParametersConnect())
            {
                MessageBox.Show("Ошибка при получении параметров конфигурации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        public bool GetParametersConnect()
        {
            try
            {
                XDocument xdoc = XDocument.Load(GetPath());
                if (xdoc.Element("Config").Element("CheckMark").Value == "True")
                {
                    _CheckMark = true;
                }
                else
                {
                    _CheckMark = false;
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
                XDocument xdoc = XDocument.Load(GetPath());

                xdoc.Element("Config").Element("CheckMark").SetValue(_CheckMark.ToString());

                xdoc.Save(GetPath());

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckMark
        {
            get
            {
                return _CheckMark;
            }

            set
            {
                _CheckMark = value;
            }
        }

        private string GetPath()
        {
            string _path = Application.StartupPath + @"\Program\Config.xml";

            if (!File.Exists(_path))
            {
                _path = Path.GetDirectoryName(Application.StartupPath) + @"\Program\Config.xml";
            }
            return _path;
        }

    }
}
