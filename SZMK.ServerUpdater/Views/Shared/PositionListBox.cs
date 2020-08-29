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

namespace SZMK.ServerUpdater.Views.Shared
{
    public partial class PositionListBox : Form, IBaseView
    {
        List<string> positions;

        public PositionListBox(List<string> positions)
        {
            InitializeComponent();

            this.positions = positions;
        }

        private void PositionListBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(Info_TB.Text))
                    {
                        throw new Exception("Необходимо указать информацию для сохранения, в противном случае нажмите отменить");
                    }
                    if (positions.FindAll(p => p == Info_TB.Text).Count > 0)
                    {
                        throw new Exception("Данные заняты");
                    }
                }
            }
            catch (Exception Ex)
            {
                e.Cancel = true;
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
    }
}
