using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.ServerUpdater.Services;
using SZMK.ServerUpdater.Views.Interfaces;
using SZMK.ServerUpdater.Views.Shared;

namespace SZMK.ServerUpdater.Views.Versions
{
    public partial class AddOrChange : Form, IBaseView
    {
        private readonly Logger logger;

        private OperationsVersions OperationsVersions;

        private bool Changed;
        private string Product;

        public AddOrChange(bool Changed, string Product, OperationsVersions OperationsVersions)
        {
            InitializeComponent();

            logger = LogManager.GetCurrentClassLogger();

            this.OperationsVersions = OperationsVersions;

            this.Changed = Changed;
            this.Product = Product;

            logger.Info("Успешная инициализация формы изменения и добавления обновления");
        }

        private void Version_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    if (Added_LB.Items.Count == 0)
                    {
                        Added_Add_B.Focus();
                        throw new Exception("Необходимо указать, что добавлено в обновлении");
                    }
                    if (Deleted_LB.Items.Count == 0)
                    {
                        Deleted_Add_B.Focus();
                        throw new Exception("Необходимо указать, что удалено в обновлении");
                    }
                    if (!Changed && String.IsNullOrEmpty(Path_TB.Text))
                    {
                        SelectProgram_B.Focus();
                        throw new Exception("Необходимо выбрать архив с программой");
                    }
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
                e.Cancel = true;
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

        private void Added_Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                PositionListBox Dialog = new PositionListBox(Added_LB.Items.Cast<String>().ToList());
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Added_LB.Items.Add(Dialog.Info_TB.Text);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Deleted_Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                PositionListBox Dialog = new PositionListBox(Deleted_LB.Items.Cast<String>().ToList());
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Deleted_LB.Items.Add(Dialog.Info_TB.Text);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Added_Change_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Added_LB.SelectedItem != null)
                {
                    PositionListBox Dialog = new PositionListBox(Added_LB.Items.Cast<String>().ToList());
                    Dialog.Info_TB.Text = Added_LB.SelectedItem.ToString();
                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {
                        Added_LB.Items[Added_LB.SelectedIndex] = Dialog.Info_TB.Text;
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать позицию для изменения");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Deleted_Change_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Deleted_LB.SelectedItem != null)
                {
                    PositionListBox Dialog = new PositionListBox(Deleted_LB.Items.Cast<String>().ToList());
                    Dialog.Info_TB.Text = Deleted_LB.SelectedItem.ToString();
                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {
                        Deleted_LB.Items[Deleted_LB.SelectedIndex] = Dialog.Info_TB.Text;
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать позицию для изменения");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Added_Delete_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Added_LB.SelectedItem != null)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить позицию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Added_LB.Items.Remove(Added_LB.SelectedItem);
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать позицию для изменения");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Deleted_Delete_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Deleted_LB.SelectedItem != null)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить позицию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Deleted_LB.Items.Remove(Deleted_LB.SelectedItem);
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать позицию для изменения");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void SelectProgram_B_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Zip Files .zip|*.zip";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Path_TB.Text = ofd.FileName;

                    if (OperationsVersions.Unzip(Path_TB.Text))
                    {
                        Version_TB.Text = OperationsVersions.GetTempVersion(Product);
                        Date_TB.Text = DateTime.Now.ToShortDateString();
                    }
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void AddOrChange_Load(object sender, EventArgs e)
        {
            if (Changed)
            {
                SelectProgram_B.Enabled = false;
            }
        }
    }
}
