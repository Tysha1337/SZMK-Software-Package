using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SZMK.Desktop.Services.Setting
{
    public class AboutProgram
    {
        private String _Version;
        private DateTime _DateUpdate;
        private readonly List<Updates> _Updates;
        private readonly List<string> _Developers;

        public AboutProgram()
        {
            if (CheckFile())
            {
                _Updates = new List<Updates>();
                _Developers = new List<String>();
                if (!GetInformations())
                {
                    throw new Exception("Ошибка при получении информации о программе");
                }
            }
            else
            {
                throw new Exception("Файл информации о программе не найден");
            }
        }
        public String Version
        {
            get
            {
                return _Version;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Version = value;
                }
            }
        }
        public DateTime DateUpdate
        {
            get
            {
                return _DateUpdate;
            }
            set
            {
                if (value != null)
                {
                    _DateUpdate = value;
                }
            }
        }
        public Updates this[Int32 Index]
        {
            get
            {
                return _Updates[Index];
            }
            set
            {
               _Updates[Index] = value;
            }
        }
        public List<Updates> GetUpdates()
        {
            return _Updates;
        }
        public List<String> GetDevelopers()
        {
            return _Developers;
        }
        public bool GetInformations()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.AboutProgram))
                {
                    throw new Exception();
                }

                XDocument xdoc = XDocument.Load(SystemArgs.Path.AboutProgram);
                _Version = xdoc.Element("Program").Element("CurretVersion").Value;
                _DateUpdate = Convert.ToDateTime(xdoc.Element("Program").Element("DateCurret").Value);
                foreach (XElement Updates in xdoc.Element("Program").Element("Updates").Elements("Update"))
                {
                    _Updates.Add(new Updates(Updates.Element("Version").Value, Convert.ToDateTime(Updates.Element("Date").Value)));
                    foreach (XElement Added in Updates.Element("Added").Elements("Item"))
                    {
                        _Updates[_Updates.Count() - 1].GetAdded().Add(Added.Value);
                    }
                    foreach (XElement Deleted in Updates.Element("Deleted").Elements("Item"))
                    {
                        _Updates[_Updates.Count() - 1].GetDeleted().Add(Deleted.Value);
                    }

                }
                foreach(XElement Developer in xdoc.Element("Program").Element("Developers").Elements("Developer"))
                {
                    _Developers.Add(Developer.Value);
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
            if (!File.Exists(SystemArgs.Path.AboutProgram))
            {
                return false;
            }

            return true;
        }
    }
}
