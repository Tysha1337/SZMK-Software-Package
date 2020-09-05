using NLog;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.TeklaInteraction.Shared.Services.Interfaces;

namespace SZMK.TeklaInteraction.Shared.Services
{
    public class MailLogger : IMailLogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Encryption encryption = new Encryption();

        private readonly string TestEmail = "rakrachok99@mail.ru";
        private readonly string LogEmail = "szmk.crashed@mail.ru";

        private String _Email;
        private String _Name;
        private String _Login;
        private String _Password;
        private String _Host;
        private int _Port;
        private bool _SSL;

        public MailLogger()
        {
            if (!GetParametersConnect())
            {
                MessageBox.Show("Ошибка при получении параметров подключения к почтовому логированию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        public bool CheckConnect()
        {
            try
            {
                MailAddress from = new MailAddress(_Email, _Name);
                MailAddress to = new MailAddress(TestEmail);
                MailMessage m = new MailMessage(from, to)
                {
                    Subject = "Тест",
                    Body = "<h2>Письмо-тест работы smtp-клиента</h2>",
                    IsBodyHtml = true
                };
                SmtpClient smtp = new SmtpClient(_Host, _Port)
                {
                    Credentials = new NetworkCredential(_Login, _Password),
                    EnableSsl = SSL,
                    Timeout = 10000
                };
                smtp.Send(m);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task AsyncSendingLog(string Message)
        {
            await Task.Run(() => SendErrorLog(Message));
        }

        public void SendErrorLog(string Message)
        {
            try
            {
                MailAddress from = new MailAddress(_Email, _Name);
                MailAddress to = new MailAddress(LogEmail);
                MailMessage m = new MailMessage(from, to)
                {
                    Subject = "Error",
                    Body = Message
                };
                SmtpClient smtp = new SmtpClient(_Host, _Port)
                {
                    Credentials = new NetworkCredential(_Login, _Password),
                    EnableSsl = _SSL,
                    Timeout = 10000
                };
                smtp.Send(m);
            }
            catch (Exception Ex)
            {
                logger.Error(Ex.Message);
            }
        }
        public bool SetParametersConnect()
        {
            try
            {
                if (CheckConnect())
                {
                    XDocument xdoc = XDocument.Load(GetPath());

                    xdoc.Element("Mail").Element("Email").SetValue(_Email);
                    xdoc.Element("Mail").Element("Name").SetValue(_Name);
                    xdoc.Element("Mail").Element("Login").SetValue(_Login);
                    xdoc.Element("Mail").Element("HashPassword").SetValue(encryption.EncryptRSA(_Password));
                    xdoc.Element("Mail").Element("Host").SetValue(_Host);
                    xdoc.Element("Mail").Element("Port").SetValue(_Port);
                    xdoc.Element("Mail").Element("SSL").SetValue(_SSL.ToString());

                    xdoc.Save(GetPath());

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool GetParametersConnect()
        {
            try
            {
                XDocument xdoc = XDocument.Load(GetPath());

                _Email = xdoc.Element("Mail").Element("Email").Value;
                _Name = xdoc.Element("Mail").Element("Name").Value;
                _Login = xdoc.Element("Mail").Element("Login").Value;
                _Password = encryption.DecryptRSA(xdoc.Element("Mail").Element("HashPassword").Value);
                _Host = xdoc.Element("Mail").Element("Host").Value;
                _Port = Convert.ToInt32(xdoc.Element("Mail").Element("Port").Value);

                if (xdoc.Element("Mail").Element("SSL").Value == "True")
                {
                    _SSL = true;
                }
                else
                {
                    _SSL = false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public String Email
        {
            get
            {
                return _Email;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Email = value;
                }
            }
        }
        public String Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Name = value;
                }
            }
        }
        public String Login
        {
            get
            {
                return _Login;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Login = value;
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
                }
            }
        }
        public String Host
        {
            get
            {
                return _Host;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Host = value;
                }
            }
        }
        public int Port
        {
            get
            {
                return _Port;
            }

            set
            {
                if (value > 0)
                {
                    _Port = value;
                }
            }
        }
        public bool SSL
        {
            get
            {
                return _SSL;
            }

            set
            {
                _SSL = value;
            }
        }
        private string GetPath()
        {
            string _path = Application.StartupPath + @"\Program\Mail.xml";

            if (!File.Exists(_path))
            {
                _path = Path.GetDirectoryName(Application.StartupPath) + @"\Program\Mail.xml";
            }
            return _path;
        }
    }
}
