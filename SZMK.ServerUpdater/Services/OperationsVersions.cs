using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.ServerUpdater.Models;

namespace SZMK.ServerUpdater.Services
{
    public class OperationsVersions : BaseOperations
    {
        public bool Add(string Product, string Version, string DateRelease, List<string> Added, List<string> Deleted)
        {
            try
            {
                MoveUpdate(Product, Version);

                if (!File.Exists($@"About\{Product}\AboutProgram.conf"))
                {
                    CreateAboutProgramFile(Product);
                }

                FormingAboutFile(Product, Version, DateRelease, Added, Deleted);

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool Unzip(string Path)
        {
            try
            {
                if (!Directory.Exists("Temp"))
                {
                    Directory.CreateDirectory(@"Temp");
                }

                using (ZipFile zip = ZipFile.Read(Path))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(@"Temp", ExtractExistingFileAction.OverwriteSilently);
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void MoveUpdate(string Product, string Version)
        {
            try
            {
                Directory.Move("Temp", $@"Products\{Product}\{Version}");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void FormingAboutFile(string Product, string Version, string DateRelease, List<string> Added, List<string> Deleted)
        {
            try
            {
                XDocument about = XDocument.Load($@"About\{Product}\AboutProgram.conf");

                about.Element("Program").Element("CurretVersion").SetValue(Version);
                about.Element("Program").Element("DateCurret").SetValue(DateRelease);

                XElement update = new XElement("Update");

                XElement version = new XElement("Version", Version);
                update.Add(version);

                XElement date = new XElement("Date", DateRelease);
                update.Add(date);

                XElement added = new XElement("Added");

                for (int i = 0; i < Added.Count; i++)
                {
                    XElement item = new XElement("Item", Added[i]);
                    added.Add(item);
                }
                update.Add(added);

                XElement deleted = new XElement("Deleted");

                for (int i = 0; i < Deleted.Count; i++)
                {
                    XElement item = new XElement("Item", Deleted[i]);
                    deleted.Add(item);
                }
                update.Add(deleted);

                about.Element("Program").Element("Updates").AddFirst(update);

                about.Save($@"About\{Product}\AboutProgram.conf");

                about.Save($@"Products\{Product}\{Version}\AboutProgram.conf");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void CreateAboutProgramFile(string Product)
        {
            try
            {
                if (!Directory.Exists($@"About\{Product}"))
                {
                    Directory.CreateDirectory($@"About\{Product}");
                }

                XDocument about = new XDocument();
                XElement program = new XElement("Program");

                XElement curretversion = new XElement("CurretVersion");
                program.Add(curretversion);

                XElement datecurret = new XElement("DateCurret");
                program.Add(datecurret);

                XElement updates = new XElement("Updates");
                program.Add(updates);

                XElement developers = new XElement("Developers");
                XElement developer = new XElement("Developer", "Ефимчик Алексей Алексеевич");
                developers.Add(developer);
                developer = new XElement("Developer", "Губанов Кирилл Николаевич");
                developers.Add(developer);
                program.Add(developers);

                about.Add(program);

                about.Save($@"About\{Product}\AboutProgram.conf");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public string GetTempVersion(string Product)
        {
            try
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(@"Temp\" + Product + @".exe");
                return myFileVersionInfo.FileVersion;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool Change(string Product, string Version, List<string> Added, List<string> Deleted)
        {
            try
            {
                ChangeAboutVersion(Product, Version, Added, Deleted);

                foreach (var changeversion in GetUpperVersions(Version, Product))
                {
                    ChangeInfoVersion(Product, changeversion, Version, Added, Deleted);
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private List<string> GetUpperVersions(string Version, string Product)
        {
            try
            {
                XDocument versions = XDocument.Load($@"About\{Product}\AboutProgram.conf");

                List<string> UpperVersions = new List<string>();

                UpperVersions.Add(Version);

                foreach (var version in versions.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().ElementsBeforeSelf())
                {
                    UpperVersions.Add(version.Element("Version").Value);
                }

                return UpperVersions;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void ChangeInfoVersion(string Product, string VersionChanged, string Version, List<string> Added, List<string> Deleted)
        {
            try
            {
                XDocument about = XDocument.Load($@"Products\{Product}\{VersionChanged}\AboutProgram.conf");

                about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Added").Elements().Remove();
                about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Deleted").Elements().Remove();

                foreach (var item in Added)
                {
                    XElement add = new XElement("Item", item);
                    about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Added").Add(add);
                }
                foreach (var item in Deleted)
                {
                    XElement del = new XElement("Item", item);
                    about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Deleted").Add(del);
                }

                about.Save($@"Products\{Product}\{VersionChanged}\AboutProgram.conf");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void ChangeAboutVersion(string Product, string Version, List<string> Added, List<string> Deleted)
        {
            try
            {
                XDocument about = XDocument.Load($@"About\{Product}\AboutProgram.conf");

                about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Added").Elements().Remove();
                about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Deleted").Elements().Remove();

                foreach (var item in Added)
                {
                    XElement add = new XElement("Item", item);
                    about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Added").Add(add);
                }
                foreach (var item in Deleted)
                {
                    XElement del = new XElement("Item", item);
                    about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Deleted").Add(del);
                }

                about.Save($@"About\{Product}\AboutProgram.conf");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool Delete(string Product, string Version)
        {
            try
            {
                Directory.Delete($@"Products\{Product}\{Version}", true);

                XDocument about = XDocument.Load($@"About\{Product}\AboutProgram.conf");

                about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Remove();

                if (about.Element("Program").Element("Updates").Elements("Update").Count() > 0)
                {
                    about.Element("Program").Element("CurretVersion").SetValue(about.Element("Program").Element("Updates").Element("Update").Element("Version").Value);
                    about.Element("Program").Element("DateCurret").SetValue(about.Element("Program").Element("Updates").Element("Update").Element("Date").Value);
                }
                else
                {
                    about.Element("Program").Element("CurretVersion").SetValue("");
                    about.Element("Program").Element("DateCurret").SetValue("");
                }

                about.Save($@"About\{Product}\AboutProgram.conf");

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<string> GetVersions(string Product)
        {
            try
            {
                List<string> versions = new List<string>();

                foreach (var version in Directory.GetDirectories($@"Products\{Product}"))
                {
                    versions.Add(Path.GetFileName(version));
                }

                return versions;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public string GetLastVersion(string Product)
        {
            try
            {
                XDocument version = XDocument.Load($@"About\{Product}\AboutProgram.conf");
                return version.Element("Program").Element("CurretVersion").Value;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<string> GetAddedInfo(string Version, string Product)
        {
            try
            {
                XDocument version = XDocument.Load($@"About\{Product}\AboutProgram.conf");

                List<string> AddedInfo = new List<string>();

                foreach (var item in version.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Added").Elements("Item"))
                {
                    AddedInfo.Add(item.Value);
                }

                return AddedInfo;

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<string> GetDeletedInfo(string Version, string Product)
        {
            try
            {
                XDocument version = XDocument.Load($@"About\{Product}\AboutProgram.conf");

                List<string> AddedInfo = new List<string>();

                foreach (var item in version.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Deleted").Elements("Item"))
                {
                    AddedInfo.Add(item.Value);
                }

                return AddedInfo;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public string GetDateVersion(string Version, string Product)
        {
            try
            {
                XDocument version = XDocument.Load($@"About\{Product}\AboutProgram.conf");

                return version.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Element("Date").Value;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
