using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services.Setting
{
    /*Данный класс реализует сервер для отправки почтовых сообщений, письмо генерируется для исполнителя у которого были найдены не выгруженные детали, а также реализован метод проверки работы сервера*/

    public class ServerMail
    {
        private String _NameWho;
        private String _SMTP;
        private String _Port;
        private String _Name;
        private String _Login;
        private String _Password;
        private String _TestUser;
        private bool _SSL;

        private String _EmailGeneralConstructor;

        public ServerMail()
        {
            if (CheckFile())
            {
                if (!GetParametersConnect())
                {
                    throw new Exception("Ошибка при получении параметров подключения к почтовому серверу");
                }
            }
            else
            {
                throw new Exception("Файл подключения к почтовому серверу не найден");
            }

            if (CheckFileEmailGeneralConstructor())
            {
                if (!GetEmailGeneralConstructor())
                {
                    throw new Exception("Ошибка при получении параметров почты главного конструктора");
                }
            }
            else
            {
                throw new Exception("Файл почты главного конструктора не найден");
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

        public String SMTP
        {
            get
            {
                return _SMTP;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _SMTP = value;
                }
            }
        }

        public String NameWho
        {
            get
            {
                return _NameWho;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _NameWho = value;
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

        public String TestUser
        {
            get
            {
                return _TestUser;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _TestUser = value;
                }
            }
        }

        public String EmailGeneralConstructor
        {
            get
            {
                return _EmailGeneralConstructor;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _EmailGeneralConstructor = value;
                }
            }
        }

        public bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.MainConnectServerMails))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(SystemArgs.Path.MainConnectServerMails, FileMode.Open)))
                {
                    _NameWho = sr.ReadLine();
                    _SMTP = sr.ReadLine();
                    _Port = sr.ReadLine();
                    _Name = sr.ReadLine();
                    _Login = sr.ReadLine();
                    _TestUser = sr.ReadLine();
                    String SSL = sr.ReadLine();

                    if (SSL.ToLower() == "true")
                    {
                        _SSL = true;
                    }
                    else
                    {
                        _SSL = false;
                    }

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
                String Dir = SystemArgs.Path.GetDirectory(SystemArgs.Path.MainConnectServerMails);

                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }

                using (StreamWriter sw = new StreamWriter(File.Open(SystemArgs.Path.MainConnectServerMails, FileMode.Create)))
                {
                    sw.WriteLine(_NameWho);
                    sw.WriteLine(_SMTP);
                    sw.WriteLine(_Port);
                    sw.WriteLine(_Name);
                    sw.WriteLine(_Login);
                    sw.WriteLine(_TestUser);

                    if (_SSL)
                    {
                        sw.WriteLine("true");
                    }
                    else
                    {
                        sw.WriteLine("false");
                    }

                    sw.WriteLine(Encryption.EncryptRSA(_Password));
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GetEmailGeneralConstructor()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.EmailGeneralConstructorPath))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(SystemArgs.Path.EmailGeneralConstructorPath, FileMode.Open)))
                {
                    _EmailGeneralConstructor = sr.ReadLine();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SetEmailGeneralConstructor()
        {
            try
            {
                String Dir = SystemArgs.Path.GetDirectory(SystemArgs.Path.EmailGeneralConstructorPath);

                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }

                using (StreamWriter sw = new StreamWriter(File.Open(SystemArgs.Path.EmailGeneralConstructorPath, FileMode.Create)))
                {
                    sw.WriteLine(_EmailGeneralConstructor);
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
            if (!File.Exists(SystemArgs.Path.MainConnectServerMails))
            {
                return false;
            }

            return true;
        }

        public bool CheckFileEmailGeneralConstructor()
        {
            if (!File.Exists(SystemArgs.Path.EmailGeneralConstructorPath))
            {
                return false;
            }

            return true;
        }

        public bool CheckConnect(String Email, String Name, String Server, Int32 Port, String Login, String Password, String TestUser)
        {
            try
            {
                MailAddress from = new MailAddress(Email, Name);
                MailAddress to = new MailAddress(TestUser);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Тест";
                m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(Server, Port);
                smtp.Credentials = new NetworkCredential(Login, Password);
                smtp.EnableSsl = true;
                smtp.Send(m);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SendMail(bool SendGeneralConstructor, string Status)
        {
            try
            {
                MailMessage m = new MailMessage();
                m.From = new MailAddress(NameWho, Name);
                if (SystemArgs.Mails.Count != 0)
                {
                    for (int i = 0; i < SystemArgs.UnLoadSpecific.ExecutorMails.Count(); i++)
                    {
                        if (SystemArgs.UnLoadSpecific.ExecutorMails[i].GetSpecifics().Where(p => !p.Finded).Count() != 0)
                        {
                            m.To.Clear();
                            //for (int j = 0; j < SystemArgs.Mails.Count; j++)
                            //{
                            //    if (SystemArgs.UnLoadSpecific.ExecutorMails[i].Executor.Equals(SystemArgs.Mails[j].Surname.Trim()+ " " + SystemArgs.Mails[j].Name.First() + "." + SystemArgs.Mails[j].MiddleName.First() + "."))
                            //    {
                            //        m.To.Add(new MailAddress(SystemArgs.Mails[j].MailAddress));
                            //    }
                            //    else if(SystemArgs.UnLoadSpecific.ExecutorMails[i].Executor.Equals(SystemArgs.Mails[j].Surname.Trim() + SystemArgs.Mails[j].Name.First() + "." + SystemArgs.Mails[j].MiddleName.First() + "." ))
                            //    {
                            //        m.To.Add(new MailAddress(SystemArgs.Mails[j].MailAddress));
                            //    }
                            //}
                            //if (m.To.Count() == 0)
                            //{
                            //    throw new Exception($"Email адрес для исполнителя {SystemArgs.UnLoadSpecific.ExecutorMails[i].Executor} не найден");
                            //}

                            //if (SendGeneralConstructor)
                            //{
                            //    m.To.Add(new MailAddress(_EmailGeneralConstructor));
                            //}
                            m.To.Add(new MailAddress("Agafonov.AE@szmk-nk.com"));
                            m.Subject = "Деталировка отсутствует от " + DateTime.Now.ToString();
                            m.Body = CreateMessage(SystemArgs.UnLoadSpecific.ExecutorMails[i], Status);
                            m.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient(SMTP, Convert.ToInt32(Port));
                            smtp.Credentials = new NetworkCredential(Login, Password);
                            smtp.EnableSsl = true;
                            smtp.Send(m);
                        }
                    }

                }
                else
                {
                    throw new Exception("Отсутсвуют адреса для отправки");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public String CreateMessage(UnLoadSpecific.ExecutorMail Executor, string Status)
        {
            try
            {


                String Message = $"<h3>{Status}<h3><table border=\"1\">" +
                                    $"<tr>" +
                                    $"<td> № заказа</td>" +
                                    $"<td> № листа</td>" +
                                    $"<td> Фамилия разработчика</td>" +
                                    $"<td> № детали</td>" +
                                    $"<td> Путь папки с деталями</td>" +
                                    $"</tr>";
                foreach (var Specifics in Executor.GetSpecifics())
                {
                    if (!Specifics.Finded)
                    {
                        Message += $"<tr>" +
                                    $"<td> {Specifics.Number}</td>" +
                                    $"<td> {Specifics.List.ToString()}</td>" +
                                    $"<td> {Executor.Executor}</td>" +
                                    $"<td> {Specifics.NumberSpecific.ToString()}</td>" +
                                    $"<td> <a href=\"{Specifics.PathDetails}\">{Specifics.PathDetails}</a> </td>" +
                                    $"</tr>";
                    }
                }
                Message += $"</table>";
                return Message;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
