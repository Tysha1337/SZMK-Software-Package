using System;
using System.Security.Cryptography;
using System.Text;
using SZMK.TeklaInteraction.Shared.Services.Interfaces;

namespace SZMK.TeklaInteraction.Shared.Services
{
    public class Hash : IHash
    {
        public String GetSHA256(String Password)
        {
            UTF8Encoding Encoder = new UTF8Encoding();
            SHA256Managed SHA256 = new SHA256Managed();
            byte[] Hash = SHA256.ComputeHash(Encoder.GetBytes(Password));

            return Convert.ToBase64String(Hash);
        }
    }
}
