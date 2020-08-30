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
        public bool Add(string Product, string Version, string DateRelease, List<string> Added, List<string> Deleted, OperationsFiles operationsFiles)
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
        public bool Upzip(string Path)
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
            Directory.Move("Temp", $@"Products\{Product}\{Version}");
        }
        private void FormingAboutFile(string Product, string Version, string DateRelease, List<string> Added, List<string> Deleted)
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
        private void CreateAboutProgramFile(string Product)
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
        public string GetTempVersion(string Product)
        {
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(@"Temp\" + Product + @".exe");
            return myFileVersionInfo.FileVersion;
        }
        public bool Delete(string Version)
        {
            try
            {
                Directory.Delete(@"Versions\" + Version, true);

                XDocument about = XDocument.Load(@"About\AboutProgram.conf");

                about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Version).First().Remove();

                about.Element("Program").Element("CurretVersion").SetValue(about.Element("Program").Element("Updates").Element("Update").Element("Version").Value);
                about.Element("Program").Element("DateCurret").SetValue(about.Element("Program").Element("Updates").Element("Update").Element("Date").Value);

                about.Save(@"About\AboutProgram.conf");

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<string> GetVersions()
        {
            try
            {
                List<string> versions = new List<string>();

                foreach (var version in Directory.GetDirectories(@"Versions"))
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
        public string GetLastVersion()
        {
            try
            {
                XDocument version = XDocument.Load(@"About\AboutProgram.conf");
                return version.Element("Program").Element("CurretVersion").Value;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
