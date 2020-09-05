using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.ServerUpdater.Services
{
    public class BaseOperations
    {
        public string ComputeMD5Checksum(string path)
        {
            try
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, (int)fs.Length);
                    byte[] checkSum = md5.ComputeHash(fileData);
                    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                    return result;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
