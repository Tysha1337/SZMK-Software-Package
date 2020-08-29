using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.Chief_PDO
{
    public partial class Chief_PDO_ChangeOrder_F : Form
    {
        public Chief_PDO_ChangeOrder_F()
        {
            InitializeComponent();
        }
        private void Chief_PDO_ChangeOrder_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    if (Executor_CB.Checked)
                    {
                        if (String.IsNullOrEmpty(Executor_TB.Text))
                        {
                            Executor_TB.Focus();
                            throw new Exception("Необходимо указать исполнителя чертежа");
                        }
                    }
                    if (Number_CB.Checked)
                    {
                        if (String.IsNullOrEmpty(Number_TB.Text))
                        {
                            Number_TB.Focus();
                            throw new Exception("Необходимо указать номер заказа");
                        }
                    }

                    if (List_CB.Checked)
                    {
                        if (String.IsNullOrEmpty(List_TB.Text))
                        {
                            List_TB.Focus();
                            throw new Exception("Необходимо указать лист");
                        }
                        if (Convert.ToInt32(List_TB.Text) <= 0)
                        {
                            List_TB.Focus();
                            throw new Exception("Лист должен быть больше 0");
                        }
                    }

                    if (Mark_CB.Checked)
                    {
                        if (String.IsNullOrEmpty(Mark_TB.Text))
                        {
                            Mark_TB.Focus();
                            throw new Exception("Необходимо указать марку");
                        }
                    }

                    if (Lenght_CB.Checked)
                    {
                        if (String.IsNullOrEmpty(Lenght_TB.Text))
                        {
                            Lenght_TB.Focus();
                            throw new Exception("Необходимо указать длину");
                        }
                        if (Convert.ToDouble(Lenght_TB.Text) <= 0)
                        {
                            List_TB.Focus();
                            throw new Exception("Длина должна быть больше 0");
                        }
                    }
                    if (Weight_CB.Checked)
                    {
                        if (String.IsNullOrEmpty(Weight_TB.Text))
                        {
                            Weight_TB.Focus();
                            throw new Exception("Необходимо указать вес");
                        }
                        if (Convert.ToDouble(Weight_TB.Text) <= 0)
                        {
                            List_TB.Focus();
                            throw new Exception("Вес должен быть больше 0");
                        }
                    }
                    if (ExecutorWork_CB.Checked)
                    {
                        if (String.IsNullOrEmpty(ExecutorWork_TB.Text))
                        {
                            Mark_TB.Focus();
                            throw new Exception("Необходимо указать исполнителя работ");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Указан неверный формат числовых полей, вес и длина вещественные числа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void Chief_PDO_ChangeOrder_F_Load(object sender, EventArgs e)
        {

        }

        private void Executor_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!Executor_CB.Checked)
            {
                Executor_TB.Enabled = false;
            }
            else
            {
                Executor_TB.Enabled = true;
            }
        }

        private void Number_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!Number_CB.Checked)
            {
                Number_TB.Enabled = false;
            }
            else
            {
                Number_TB.Enabled = true;
            }
        }

        private void List_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!List_CB.Checked)
            {
                List_TB.Enabled = false;
            }
            else
            {
                List_TB.Enabled = true;
            }
        }

        private void Mark_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!Mark_CB.Checked)
            {
                Mark_TB.Enabled = false;
            }
            else
            {
                Mark_TB.Enabled = true;
            }
        }

        private void Lenght_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!Lenght_CB.Checked)
            {
                Lenght_TB.Enabled = false;
            }
            else
            {
                Lenght_TB.Enabled = true;
            }
        }

        private void Weight_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!Weight_CB.Checked)
            {
                Weight_TB.Enabled = false;
            }
            else
            {
                Weight_TB.Enabled = true;
            }
        }

        private void ExecutorWork_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!ExecutorWork_CB.Checked)
            {
                ExecutorWork_TB.Enabled = false;
            }
            else
            {
                ExecutorWork_TB.Enabled = true;
            }
        }

        private void FinishedRewrite_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (!FinishedRewrite_CB.Checked)
            {
                Finished_CB.Enabled = false;
            }
            else
            {
                Finished_CB.Enabled = true;
            }
        }
    }
}
