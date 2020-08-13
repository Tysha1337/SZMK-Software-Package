using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.BotLogger.Services.Settings;

namespace SZMK.BotLogger.Services
{
    public class OperationsProducts
    {
        public void AddProduct(string Name)
        {
            try
            {
                XDocument doc = XDocument.Load(PathProgram.Products);
                doc.Element("Products").Add(new XElement("Product", Name));
                doc.Save(PathProgram.Products);

                Directory.CreateDirectory(@"Products\" + Name);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void DeleteProduct(string Name)
        {
            try
            {
                XDocument doc = XDocument.Load(PathProgram.Products);

                doc.Element("Products").Elements("Product").Where(p => p.Value == Name).Remove();

                doc.Save(PathProgram.Products);

                foreach(var log in Directory.GetFiles(@"Products\" + Name))
                {
                    File.Delete(log);
                }

                Directory.Delete(@"Products\" + Name);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
