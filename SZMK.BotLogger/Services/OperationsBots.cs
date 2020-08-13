using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.BotLogger.Services.Settings;

namespace SZMK.BotLogger.Services
{
    public class OperationsBots
    {
        public bool SaveTelegramBot(string Token, string Host, string Port)
        {
            try
            {
                XDocument Telegram = XDocument.Load(PathProgram.TelegramBot);

                Telegram.Element("Settings").Element("Token").SetValue(Token);

                if (!String.IsNullOrEmpty(Host) && !String.IsNullOrEmpty(Port))
                {
                    Telegram.Element("Settings").Element("Host").SetValue(Host);

                    int _Port = Convert.ToInt32(Port);

                    Telegram.Element("Settings").Element("Port").SetValue(Port);
                }
                else
                {
                    Telegram.Element("Settings").Element("Host").SetValue("");
                    Telegram.Element("Settings").Element("Port").SetValue("");
                }

                Telegram.Save(PathProgram.TelegramBot);

                return true;
            }
            catch (ArgumentException)
            {
                throw new Exception("Порт должен быть целым числом");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
