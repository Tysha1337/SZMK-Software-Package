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

namespace SZMK.ServerUpdater.Views
{
    public partial class Main : Form, IBaseView
    {
        private OperationsVersions Versions;
        private OperationsFiles OperationsFiles;
        private Server Server;

        public Main()
        {
            InitializeComponent();
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                Version Dialog = new Version(false);
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    if (Versions.Add(Dialog.Version_TB.Text, Dialog.DateRelease_DTP.Value, Dialog.Added_LB.Items.Cast<string>().ToList(), Dialog.Deleted_LB.Items.Cast<string>().ToList(), Dialog.Path_TB.Text, OperationsFiles))
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

        private void Change_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Versions_DGV.CurrentCell != null)
                {
                    Version Dialog = new Version(true);

                    XDocument about = XDocument.Load(@"About\AboutProgram.conf");

                    XElement update = about.Element("Program").Element("Updates").Elements("Update").Where(p => p.Element("Version").Value == Versions_DGV.CurrentCell.Value.ToString()).First();

                    Dialog.Version_TB.Text = Versions_DGV.CurrentCell.Value.ToString();

                    Dialog.DateRelease_DTP.Value = Convert.ToDateTime(update.Element("Date").Value);

                    foreach (var item in update.Element("Added").Elements("Item"))
                    {
                        Dialog.Added_LB.Items.Add(item.Value);
                    }

                    foreach (var item in update.Element("Deleted").Elements("Item"))
                    {
                        Dialog.Deleted_LB.Items.Add(item.Value);
                    }

                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!String.IsNullOrEmpty(Dialog.Path_TB.Text))
                        {
                            if (Versions.Delete(Versions_DGV.CurrentCell.Value.ToString()))
                            {
                                if (Versions.Add(Dialog.Version_TB.Text, Dialog.DateRelease_DTP.Value, Dialog.Added_LB.Items.Cast<string>().ToList(), Dialog.Deleted_LB.Items.Cast<string>().ToList(), Dialog.Path_TB.Text, OperationsFiles))
                                {
                                    Info("Успешное редактирование версии!");
                                }
                            }
                        }
                        else
                        {
                            Directory.Move(@"Versions\" + Versions_DGV.CurrentCell.Value.ToString(), @"Versions\" + Dialog.Version_TB.Text);

                            Versions_DGV.CurrentCell.Value = Dialog.Version_TB.Text;

                            if (update.Element("Version").Value == about.Element("Program").Element("CurretVersion").Value)
                            {
                                about.Element("Program").Element("CurretVersion").SetValue(Dialog.Version_TB.Text);
                                about.Element("Program").Element("DateCurret").SetValue(Dialog.DateRelease_DTP.Value.ToShortDateString());
                            }

                            update.Element("Version").SetValue(Dialog.Version_TB.Text);
                            update.Element("Date").SetValue(Dialog.DateRelease_DTP.Value.ToShortDateString());

                            update.Element("Added").Elements().Remove();
                            update.Element("Deleted").Elements().Remove();

                            foreach (var item in Dialog.Added_LB.Items)
                            {
                                XElement el = new XElement("Item", item);
                                update.Element("Added").Add(el);
                            }

                            foreach (var item in Dialog.Deleted_LB.Items)
                            {
                                XElement el = new XElement("Item", item);
                                update.Element("Deleted").Add(el);
                            }

                            about.Save(@"About\AboutProgram.conf");
                            about.Save(@"Versions\" + Dialog.Version_TB.Text + @"\Program\AboutProgram.conf");
                        }
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
                        if (Versions.Delete(Versions_DGV.CurrentCell.Value.ToString()))
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
                Versions = new OperationsVersions();
                OperationsFiles = new OperationsFiles();

                Server = new Server(OperationsFiles, Versions);

                List<string> list_versions = Versions.GetVersions();

                foreach (var item in list_versions)
                {
                    Versions_DGV.Rows.Add(item);
                }

                Server.Start();
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings settings = new Settings(OperationsFiles);

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
    }
}
