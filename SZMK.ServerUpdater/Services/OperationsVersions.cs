using Ionic.Zip;
using System;
using System.Collections.Generic;
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
        public bool Add(string Version, DateTime DateRelease, List<string> Added, List<string> Deleted, string Path, OperationsFiles operationsFiles)
        {
            try
            {
                if (Upzip(Path, Version))
                {
                    XDocument about = XDocument.Load(@"About\AboutProgram.conf");

                    about.Element("Program").Element("CurretVersion").SetValue(Version);
                    about.Element("Program").Element("DateCurret").SetValue(DateRelease.ToShortDateString());

                    XElement update = new XElement("Update");

                    XElement version = new XElement("Version", Version);
                    update.Add(version);

                    XElement date = new XElement("Date", DateRelease.ToShortDateString());
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

                    about.Save(@"About\AboutProgram.conf");

                    about.Save(@"Versions\" + Version + @"\Program\AboutProgram.conf");

                    operationsFiles.FormingSettingsUpdate(operationsFiles.GetParametersFiles(Version));
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private bool Upzip(string Path, string Version)
        {
            try
            {
                CheckDirectory();

                Directory.CreateDirectory(@"Versions\" + Version);

                using (ZipFile zip = ZipFile.Read(Path))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(@"Versions\" + Version, ExtractExistingFileAction.OverwriteSilently);
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void CheckDirectory()
        {
            try
            {
                if (!Directory.Exists("Versions"))
                {
                    Directory.CreateDirectory("Versions");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
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
