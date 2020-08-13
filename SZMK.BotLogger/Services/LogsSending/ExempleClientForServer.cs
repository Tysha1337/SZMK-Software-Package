using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.BotLogger.Services.LogsSending
{
    public class ExempleClientForServer
    {
        public void SendAndRead()
        {
            TcpClient tcpClient = new TcpClient("10.103.145.149", 49000);
            using (NetworkStream outputStream = tcpClient.GetStream())
            {
                using (BinaryWriter writer = new BinaryWriter(outputStream))
                {
                    writer.Write("Logs");
                    writer.Write("Desktop");
                    writer.Write(Dns.GetHostName());
                    writer.Write("Info");
                    writer.Write("Test message");
                }
            }
            tcpClient.Close();
        }
    }
}
