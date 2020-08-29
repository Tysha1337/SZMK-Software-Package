using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services
{
    class Hash
    {
        public static String GetSHA256(String Password)
        {
            UTF8Encoding Encoder = new UTF8Encoding();
            SHA256Managed SHA256 = new SHA256Managed();
            byte[] Hash = SHA256.ComputeHash(Encoder.GetBytes(Password));

            SystemArgs.PrintLog($"Хеш-последовательность успешно получена");

            return Convert.ToBase64String(Hash);
        }
    }
}
