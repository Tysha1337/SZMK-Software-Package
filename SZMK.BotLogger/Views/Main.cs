using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using SZMK.BotLogger.Services;
using SZMK.BotLogger.Services.LogsReceiving;
using SZMK.BotLogger.Services.LogsSending;
using SZMK.BotLogger.Services.Settings;
using SZMK.BotLogger.Views.Interfaces;

namespace SZMK.BotLogger.Views
{
    public partial class Main : Form, IBaseView
    {
        private OperationsProducts products;
        private OperationsBots Operationsbots;
        private OperationsServer Operationsserver;
        private Server Server;
        private BotTelegram telegram;

        public Main()
        {
            InitializeComponent();
        }

        private void AddProduct_B_Click(object sender, EventArgs e)
        {
            try
            {
                AddProduct Dialog = new AddProduct();
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    products.AddProduct(Dialog.ProductName_TB.Text);

                    ViewProducts();

                    MessageBox.Show("Успешное добавление продукта", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }
        private void ViewProducts()
        {
            try
            {
                XDocument doc = XDocument.Load(PathProgram.Products);

                List<string> products = doc.Element("Products").Elements("Product").Select(p => p.Value).ToList();

                Products_DGV.Rows.Clear();

                foreach (string product in products)
                {
                    Products_DGV.Rows.Add(product);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void ViewBots()
        {
            try
            {
                XDocument doc = XDocument.Load(PathProgram.TelegramBot);

                TelegramToken_TB.Text = doc.Element("Settings").Element("Token").Value;
                TelegramHost_TB.Text = doc.Element("Settings").Element("Host").Value;
                TelegramPort_TB.Text = doc.Element("Settings").Element("Port").Value;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void ViewServer()
        {
            try
            {
                XDocument doc = XDocument.Load(PathProgram.Server);

                string host = Dns.GetHostName();

                IPServer_TB.Text = Dns.GetHostByName(host).AddressList[0].ToString();

                PortServer_TB.Text = doc.Element("Settings").Element("Port").Value;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void LoadProducts()
        {
            try
            {
                XDocument doc = XDocument.Load(PathProgram.Products);

                List<string> products = doc.Element("Products").Elements("Product").Select(p => p.Value).ToList();

                Products_CB.Items.Clear();

                foreach (string product in products)
                {
                    Products_CB.Items.Add(product);
                }

                Products_CB.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Products_DGV.AutoGenerateColumns = false;

                products = new OperationsProducts();
                Operationsbots = new OperationsBots();
                Operationsserver = new OperationsServer();
                Server = new Server();
                telegram = new BotTelegram();

                Server.Start();
                telegram.StartAsync();

                LoadProducts();
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab.Text == "Настройки")
                {
                    ViewProducts();
                }
                else
                {
                    LoadProducts();
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab.Text == "Продукты")
            {
                ViewProducts();
            }
            else if (tabControl2.SelectedTab.Text == "Боты")
            {
                ViewBots();
            }
            else
            {
                ViewServer();
            }
        }

        private void DeleteProduct_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Products_DGV.CurrentCell != null)
                {

                    if (MessageBox.Show("Вы действительно хотите удалить продукт?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string NameProduct = Products_DGV.CurrentCell.Value.ToString();

                        products.DeleteProduct(NameProduct);

                        ViewProducts();
                    }
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void SaveBotSettings_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Operationsbots.SaveTelegramBot(TelegramToken_TB.Text, TelegramHost_TB.Text, TelegramPort_TB.Text))
                {
                    MessageBox.Show("Успешное сохранение параметров", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        public void Info(string Message)
        {
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warn(string Message)
        {
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(string Message)
        {
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SaveServer_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Operationsserver.Save(PortServer_TB.Text))
                {
                    Server.Stop();
                    Server.Start();
                    MessageBox.Show("Успешное сохранение параметров", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void Products_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string LogPath = @"Products\" + Products_CB.SelectedItem.ToString();

                List<string> files = Directory.GetFiles(LogPath).ToList();

                Logs_DGV.Rows.Clear();

                for (int i = 0; i < files.Count(); i++)
                {
                    Logs_DGV.Rows.Add(Path.GetFileNameWithoutExtension(files[i]));
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void Logs_DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (Logs_DGV.CurrentCell != null && Logs_DGV.CurrentCell.RowIndex >= 0 && e.RowIndex >= 0)
                {
                    Process.Start($@"Products\{Products_CB.SelectedItem}\{Logs_DGV.CurrentCell.Value}.log");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }
    }
}
