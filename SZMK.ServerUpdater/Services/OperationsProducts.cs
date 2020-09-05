using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SZMK.ServerUpdater.Services
{
    public class OperationsProducts
    {
        string SettingsPath = @"Program\Settings\Products\Settings.conf";
        string FolderPath = @"Products";

        public void Add(string Name)
        {
            try
            {
                XDocument products = XDocument.Load(SettingsPath);

                XElement product = new XElement("Product", Name);
                products.Element("Products").Add(product);

                products.Save(SettingsPath);

                Directory.CreateDirectory(FolderPath + @"\" + Name);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void Change(string OldName, string NewName)
        {
            try
            {
                XDocument products = XDocument.Load(SettingsPath);

                products.Element("Products").Elements("Product").Where(p => p.Value == OldName).First().SetValue(NewName);

                products.Save(SettingsPath);

                string RenameFolder = Directory.GetDirectories(FolderPath).Where(p => Path.GetFileName(p) == OldName).First();

                Directory.Move(RenameFolder, Path.GetDirectoryName(RenameFolder) + @"\" + NewName);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void Delete(string Name)
        {
            try
            {
                XDocument products = XDocument.Load(SettingsPath);

                products.Element("Products").Elements("Product").Where(p => p.Value == Name).First().Remove();

                products.Save(SettingsPath);

                Directory.Delete(FolderPath + @"\" + Name, true);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<string> GetProducts()
        {
            try
            {
                XDocument data = XDocument.Load(SettingsPath);
                return data.Element("Products").Elements("Product").Select(p => p.Value).ToList();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
