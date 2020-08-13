using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.BotLogger.Services.Settings;

namespace SZMK.BotLogger.Services
{
    public class OperationsServer
    {
        public bool Save(string Port)
        {
            try
            {
                XDocument server = XDocument.Load(PathProgram.Server);

                int _Port = Convert.ToInt32(Port);

                server.Element("Settings").Element("Port").SetValue(Port);

                server.Save(PathProgram.Server);

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
