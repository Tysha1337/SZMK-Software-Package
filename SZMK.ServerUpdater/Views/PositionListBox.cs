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
    public partial class PositionListBox : Form, IBaseView
    {
        public PositionListBox()
        {
            InitializeComponent();
        }

        private void PositionListBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(Info_TB.Text))
                    {
                        Info_TB.Focus();
                        throw new Exception("Необходимо заполнить информацию");
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
    }
}
