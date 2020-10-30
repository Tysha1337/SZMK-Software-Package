using Microsoft.Win32;
using NLog;
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
        private readonly Logger logger;

        private OperationsVersions OperationsVersions;
        private OperationsFiles OperationsFiles;
        private OperationsProducts OperationsProducts;
        private Services.Server Server;

        private BindingList<string> Products;

        const string pathRegistryKeyStartup = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        const string applicationName = "SZMK.ServerUpdater";
        String value = "";

        public Main()
        {
            InitializeComponent();

            logger = LogManager.GetCurrentClassLogger();

            logger.Info("Инициализация основной формы пройдена успешно");
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrChange Dialog = new AddOrChange(false, Product_CB.Text, OperationsVersions);
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    if (OperationsVersions.Add(Product_CB.Text, Dialog.Version_TB.Text, Dialog.Date_TB.Text, Dialog.Added_LB.Items.Cast<string>().ToList(), Dialog.Deleted_LB.Items.Cast<string>().ToList()))
                    {
                        Versions_DGV.Rows.Add(Dialog.Version_TB.Text);
                        Info("Добавление было успешно произведено");
                    }
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }
        private void Change_B_Click(object sender, EventArgs e)
        {
            if (Versions_DGV.CurrentCell != null)
            {
                AddOrChange Dialog = new AddOrChange(true, Product_CB.Text, OperationsVersions);

                Dialog.Version_TB.Text = Versions_DGV.CurrentCell.Value.ToString();

                foreach (var item in OperationsVersions.GetAddedInfo(Versions_DGV.CurrentCell.Value.ToString(), Product_CB.Text))
                {
                    Dialog.Added_LB.Items.Add(item);
                }
                foreach (var item in OperationsVersions.GetDeletedInfo(Versions_DGV.CurrentCell.Value.ToString(), Product_CB.Text))
                {
                    Dialog.Deleted_LB.Items.Add(item);
                }

                Dialog.Date_TB.Text = OperationsVersions.GetDateVersion(Versions_DGV.CurrentCell.Value.ToString(), Product_CB.Text);

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    if (OperationsVersions.Change(Product_CB.Text, Dialog.Version_TB.Text, Dialog.Added_LB.Items.Cast<string>().ToList(), Dialog.Deleted_LB.Items.Cast<string>().ToList()))
                    {
                        Info("Изменение информации было успешно произведено");
                    }
                }
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
                Error(Ex);
            }
        }

        public void Info(string Message)
        {
            logger.Info(Message);
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warn(string Message)
        {
            logger.Warn(Message);
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(Exception Ex)
        {
            logger.Error(Ex.ToString());
            MessageBox.Show(Ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                OperationsVersions = new OperationsVersions();
                OperationsFiles = new OperationsFiles();
                OperationsProducts = new OperationsProducts();
                Server = new Services.Server(OperationsFiles, OperationsVersions);

                CheckerStatus_T.Start();

                logger.Info("Сборка пройдена успешно");

                Server.Start();

                logger.Info("Запуск сервера успешно выполнен");

                ShowProducts();

                using (RegistryKey registryKeyStartup = Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
                {
                    value = (String)registryKeyStartup.GetValue("SZMK.ServerUpdater");
                }
                if (!String.IsNullOrEmpty(value))
                {
                    AddAutoRun_TSM.Text = "Удалить из автозагрузки";
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
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
                Error(Ex);
            }
        }

        private void Products_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsProducts products = new SettingsProducts(Products);

                products.Products_LB.DataSource = Products;

                products.Show();

                logger.Info("Выполнен показ настройки продуктов");
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void ShowProducts()
        {
            try
            {
                Products = new BindingList<string>(OperationsProducts.GetProducts());
                Product_CB.DataSource = Products;

                logger.Info("Успешный показ продуктов");
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Product_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception Ex)
            {
                Error(Ex);
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
            try
            {
                CheckerStatus_T.Stop();
                Server.Stop();
                logger.Info("Выполнена остановка сервера и закрытие программы");
                Environment.Exit(0);
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void StartServer_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Server.GetStatus())
                {
                    Server.Start();
                }
                else
                {
                    Info("Сервер уже запущен");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void StopServer_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Server.GetStatus())
                {
                    Server.Stop();
                }
                else
                {
                    Info("Сервер уже остановлен");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void CheckerStatus_T_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Server.GetStatus())
                {
                    StatusServer_TB.Text = "Работает";
                    StatusServer_TB.BackColor = Color.GreenYellow;
                }
                else
                {
                    StatusServer_TB.Text = "Остановлен";
                    StatusServer_TB.BackColor = Color.OrangeRed;
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void AddAutoRun_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(value))
                {
                    using (RegistryKey registryKeyStartup = Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
                    {
                        registryKeyStartup.DeleteValue(applicationName, false);
                    }
                    value = "";
                    AddAutoRun_TSM.Text = "Добавить в автозагрузку";
                }
                else
                {
                    using (RegistryKey registryKeyStartup = Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
                    {
                        registryKeyStartup.SetValue(applicationName, Application.ExecutablePath);
                    }
                    value = "SZMK.ServerUpdater";
                    AddAutoRun_TSM.Text = "Удалить из автозагрузки";
                }
            }
            catch (Exception E)
            {
                Error(E);
            }
        }
    }
}
