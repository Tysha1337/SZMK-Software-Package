using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.KB
{
    public partial class KB_SettingScannerPort_F : Form
    {
        public KB_SettingScannerPort_F()
        {
            InitializeComponent();
        }

        private void ShowKSK_Click(object sender, EventArgs e)
        {
            KB_CodeSettingScanner_F Dialog = new KB_CodeSettingScanner_F();
            Dialog.ShowDialog();

            WB_LB.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    WB_LB.Items.Add(port);
                }
                WB_LB.SelectedIndex = 0;
            }
        }
    }
}
