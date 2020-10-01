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
        public List<FileAndMove> GetLastFiles(string OldVersion, string LastVerison, string Product)
        {
            try
            {
                List<FileAndMove> LastUpdateFiles = new List<FileAndMove>();

                List<FileAndHash> OldFiles = GetHashFiles(Product, OldVersion);
                List<FileAndHash> LastFiles = GetHashFiles(Product, LastVerison);

                List<string> removefiles = new List<string>();

                for(int i = 0; i < OldFiles.Count; i++)
                {
                    if (LastFiles.FindAll(p => p.Hash == OldFiles[i].Hash && p.FileName == OldFiles[i].FileName).Count == 0)
                    {
                        removefiles.Add(OldFiles[i].FileName);
                    }
                }

                List<string> addfiles = new List<string>();

                for (int i = 0; i < LastFiles.Count; i++)
                {
                    if (OldFiles.FindAll(p => p.Hash == LastFiles[i].Hash && p.FileName == LastFiles[i].FileName).Count == 0)
                    {
                        addfiles.Add(LastFiles[i].FileName);
                    }
                }

                foreach (var file in removefiles)
                {
                    LastUpdateFiles.Add(new FileAndMove { FileName = file, Move = "Remove" });
                }
                foreach (var file in addfiles)
                {
                    LastUpdateFiles.Add(new FileAndMove { FileName = file, Move = "Add" });
                }

                return LastUpdateFiles;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private List<FileAndHash> GetHashFiles(string Product, string Version)
        {
            try
            {
                List<FileAndHash> files = new List<FileAndHash>();

                foreach (var file in Directory.GetFiles($@"Products\{Product}\{Version}", "*.*", SearchOption.AllDirectories))
                {
                    files.Add(new FileAndHash { FileName = file.Remove(0, file.IndexOf($@"{Product}\{Version}") + $@"{Product}\{Version}".Length + 1), Hash = ComputeMD5Checksum(file) });
                }

                return files;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
