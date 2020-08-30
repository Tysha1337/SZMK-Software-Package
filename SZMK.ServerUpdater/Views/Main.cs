using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.ServerUpdater.Services;
using SZMK.ServerUpdater.Views.Interfaces;
using SZMK.ServerUpdater.Views.Settings;
using SZMK.ServerUpdater.Views.Versions;

namespace SZMK.ServerUpdater.Views
{
    public partial class Main : Form, IBaseView
    {
        private OperationsVersions OperationsVersions;
        private OperationsFiles OperationsFiles;
        private OperationsProducts OperationsProducts;
        private Services.Server Server;

        private BindingList<string> Products;

        public Main()
        {
            InitializeComponent();
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrChange Dialog = new AddOrChange(false, Product_CB.Text, OperationsVersions);
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    if (OperationsVersions.Add(Product_CB.Text, Dialog.Version_TB.Text, Dialog.Date_TB.Text, Dialog.Added_LB.Items.Cast<string>().ToList(), Dialog.Deleted_LB.Items.Cast<string>().ToList(), OperationsFiles))
                    {
                        Versions_DGV.Rows.Add(Dialog.Version_TB.Text);
                        Info("Добавление было успешно произведено");
                    }
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Versions_DGV.CurrentCell != null)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить продукт?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (OperationsVersions.Delete(Product_CB.Text, Versions_DGV.CurrentCell.Value.ToString()))
                        {
                            Versions_DGV.Rows.RemoveAt(Versions_DGV.CurrentCell.RowIndex);
                            Info("Удаление прошло успешно");
                        }
                    }
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

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                OperationsVersions = new OperationsVersions();
                OperationsFiles = new OperationsFiles();
                OperationsProducts = new OperationsProducts();
                Server = new Services.Server(OperationsFiles, OperationsVersions);

                Server.Start();

                ShowProducts();
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void Server_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Server settings = new Settings.Server(OperationsFiles);

                XDocument doc = XDocument.Load(@"Program\Settings\Connect\connect.conf");

                string host = Dns.GetHostName();

                settings.IP_TB.Text = Dns.GetHostByName(host).AddressList[0].ToString();

                settings.Port_TB.Text = doc.Element("Connect").Element("Port").Value;

                if (settings.ShowDialog() == DialogResult.OK)
                {
                    doc.Element("Connect").Element("Port").SetValue(settings.Port_TB.Text);
                    doc.Save(@"Program\Settings\Connect\connect.conf");

                    Info("Настройки успешно сохранены");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void Products_TSM_Click(object sender, EventArgs e)
        {
            SettingsProducts products = new SettingsProducts(Products);

            products.Products_LB.DataSource = Products;

            products.Show();
        }

        private void ShowProducts()
        {
            Products = new BindingList<string>(OperationsProducts.GetProducts());
            Product_CB.DataSource = Products;
        }

        private void Product_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Product_CB.Text))
            {
                List<string> versions = OperationsVersions.GetVersions(Product_CB.Text);

                Versions_DGV.Rows.Clear();

                for (int i = 0; i < versions.Count; i++)
                {
                    Versions_DGV.Rows.Add(versions[i]);
                }
            }
            else
            {
                Versions_DGV.Rows.Clear();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tray.ShowBalloonTip(5);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            e.Cancel = true;
        }

        private void Open_TSMI_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void Exit_TSMI_Click(object sender, EventArgs e)
        {
            Server.Stop();
            Environment.Exit(0);
        }
    }
}
