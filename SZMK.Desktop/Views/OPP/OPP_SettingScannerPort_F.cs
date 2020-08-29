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

namespace SZMK.Desktop.Views.OPP
{
    public partial class OPP_SettingScannerPort_F : Form
    {
        public OPP_SettingScannerPort_F()
        {
            InitializeComponent();
        }

        private void ShowKSK_B_Click(object sender, EventArgs e)
        {
            OPP_CodeSettingScanner_F Dialog = new OPP_CodeSettingScanner_F();
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
