using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.ServerUpdater.Views.Interfaces;

namespace SZMK.ServerUpdater.Views
{
    public partial class Version : Form, IBaseView
    {
        private bool Changed;

        public Version(bool Changed)
        {
            InitializeComponent();
            this.Changed = Changed;
        }

        private void Version_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    if (!Version_TB.MaskCompleted)
                    {
                        Version_TB.Focus();
                        throw new Exception("Необходимо указать версию обновления");
                    }
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
                Error(Ex.Message);
                e.Cancel = true;
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

        private void Added_Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                PositionListBox Dialog = new PositionListBox();
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Added_LB.Items.Add(Dialog.Info_TB.Text);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void Deleted_Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                PositionListBox Dialog = new PositionListBox();
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Deleted_LB.Items.Add(Dialog.Info_TB.Text);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }

        private void Added_Change_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Added_LB.SelectedItem != null)
                {
                    PositionListBox Dialog = new PositionListBox();
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
                Error(Ex.Message);
            }
        }

        private void Deleted_Change_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Deleted_LB.SelectedItem != null)
                {
                    PositionListBox Dialog = new PositionListBox();
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
                Error(Ex.Message);
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
                Error(Ex.Message);
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
                Error(Ex.Message);
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
                }
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
        }
    }
}
