using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.TeklaInteraction.Shared.Services.Interfaces;

namespace SZMK.TeklaInteraction.Shared.Services
{
    public class Login : ILogin
    {
        private readonly Encryption encryption = new Encryption();

        private string _Login;
        private string _Password;

        public Login()
        {
            if (!GetParameters())
            {
                MessageBox.Show("Ошибка при получении параметров пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        public bool GetParameters()
        {
            try
            {
                XDocument xdoc = XDocument.Load(GetPath());
                _Login = xdoc.Element("User").Element("Login").Value;
                _Password = encryption.DecryptRSA(xdoc.Element("User").Element("HashPassword").Value);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetParameters()
        {
            try
            {
                XDocument xdoc = XDocument.Load(GetPath());

                xdoc.Element("User").Element("Login").SetValue(_Login);
                xdoc.Element("User").Element("HashPassword").SetValue(encryption.EncryptRSA(_Password));

                xdoc.Save(GetPath());

                return true;
            }
            catch
            {
                return false;
            }
        }
        public string LoginUser
        {
            get
            {
                return _Login;
            }

            set
            {
                _Login = value;
            }
        }
        public string PasswordUser
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }
        private string GetPath()
        {
            string _path = Application.StartupPath + @"\Program\Login.xml";

            if (!File.Exists(_path))
            {
                _path = Path.GetDirectoryName(Application.StartupPath) + @"\Program\Login.xml";
            }
            return _path;
        }
    }
}
