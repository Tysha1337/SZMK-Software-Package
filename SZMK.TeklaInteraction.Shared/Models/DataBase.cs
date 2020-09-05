using Npgsql;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.TeklaInteraction.Shared.Services;

namespace SZMK.TeklaInteraction.Shared.Models
{
    public class DataBase
    {
        private readonly Encryption encryptin = new Encryption();

        private String _Name;
        private String _Owner;
        private String _Port;
        private String _IP;
        private String _Password;

        public DataBase()
        {
            if (!GetParametersConnect())
            {
                MessageBox.Show("Ошибка при получении параметров подключения к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
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
                if (!String.IsNullOrEmpty(value))
                {
                    _Name = value;
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

        public void CheckParameters()
        {
            if (String.IsNullOrEmpty(_Name) || _Name.Trim() != "SZMK")
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
                XDocument xdoc = XDocument.Load(GetPath());

                _Name = xdoc.Element("DataBase").Element("Name").Value;
                _Owner = xdoc.Element("DataBase").Element("Owner").Value;
                _IP = xdoc.Element("DataBase").Element("IP").Value;
                _Port = xdoc.Element("DataBase").Element("Port").Value;
                _Password = encryptin.DecryptRSA(xdoc.Element("DataBase").Element("HashPassword").Value);

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
                if (CheckConnect())
                {
                    XDocument xdoc = XDocument.Load(GetPath());

                    xdoc.Element("DataBase").Element("Name").SetValue(_Name);
                    xdoc.Element("DataBase").Element("Owner").SetValue(_Owner);
                    xdoc.Element("DataBase").Element("IP").SetValue(_IP);
                    xdoc.Element("DataBase").Element("Port").SetValue(_Port);
                    xdoc.Element("DataBase").Element("HashPassword").SetValue(encryptin.EncryptRSA(_Password));

                    xdoc.Save(GetPath());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckConnect()
        {
            try
            {
                using (var Connect = new NpgsqlConnection(ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT 1", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                Connect.Close();
                                return true;
                            }
                        }
                    }

                    Connect.Close();
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        private string GetPath()
        {
            string _path = Application.StartupPath + @"\Program\DataBase.xml";

            if (!File.Exists(_path))
            {
                _path = Path.GetDirectoryName(Application.StartupPath) + @"\Program\DataBase.xml";
            }
            return _path;
        }

        public override string ToString()
        {
            return $@"Server = {_IP}; Port = {_Port}; User Id = {_Owner}; Password = {_Password}; Database = {_Name};";
        }
    }
}
