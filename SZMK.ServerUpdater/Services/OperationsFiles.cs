using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.ServerUpdater.Models;

namespace SZMK.ServerUpdater.Services
{
    public class OperationsFiles : BaseOperations
    {
        public void FormingSettingsUpdate(List<LastUpdateFiles> files)
        {
            try
            {
                string Path = @"Program\Settings\Update";

                if (!Directory.Exists(Path))
                {
                    throw new Exception("Директория сохранения настроек обновления не найден");
                }

                XDocument settings = new XDocument();

                XElement main = new XElement("Update");

                foreach (var file in files)
                {
                    XElement item = new XElement("File");

                    XElement filename = new XElement("FileName", file.FileName);
                    item.Add(filename);
                    XElement Hash = new XElement("Hash", file.Hash);
                    item.Add(Hash);
                    XElement NeedUpdate = new XElement("NeedUpdate", file.NeedUpdate);
                    item.Add(NeedUpdate);

                    main.Add(item);
                }

                settings.Add(main);

                settings.Save(Path + @"\Settings.conf");

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<LastUpdateFiles> GetSettingsUpdate()
        {
            try
            {
                string Path = @"Program\Settings\Update\Settings.conf";

                if (!File.Exists(Path))
                {
                    throw new Exception("Файл сохранения настроек обновления не найден");
                }

                XDocument settings = XDocument.Load(Path);

                List<LastUpdateFiles> files = new List<LastUpdateFiles>();

                foreach (var file in settings.Element("Update").Elements("File"))
                {
                    files.Add(new LastUpdateFiles { FileName = file.Element("FileName").Value, Hash = file.Element("Hash").Value, NeedUpdate = Convert.ToBoolean(file.Element("NeedUpdate").Value) });
                }

                return files;

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<LastUpdateFiles> GetParametersFiles(string Version)
        {
            try
            {
                List<LastUpdateFiles> LastUpdateFiles = new List<LastUpdateFiles>();

                string PathLastVersion = @"Versions\" + Version;

                List<string> Files = Directory.GetFiles(PathLastVersion, "*.*", SearchOption.AllDirectories).ToList();

                for (int i = 0; i < Files.Count; i++)
                {
                    string PerfectPath = Files[i].Remove(0, Files[i].IndexOf(PathLastVersion) + PathLastVersion.Length + 1);

                    if (Directory.GetParent(Directory.GetParent(PerfectPath).FullName).Name != "Log")
                    {
                        LastUpdateFiles.Add(new LastUpdateFiles { FileName = PerfectPath, Hash = ComputeMD5Checksum(Files[i]), NeedUpdate = true });
                    }
                }

                return LastUpdateFiles;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
