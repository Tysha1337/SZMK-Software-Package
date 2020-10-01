using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Views.Shared.Interfaces;

namespace SZMK.Desktop.Views.Shared
{
    public partial class ForLongOperations_F : Form, INotifyProcess
    {
        delegate void NotifyCallback(int value, string message);

        public ForLongOperations_F()
        {
            InitializeComponent();
        }
        public void Notify(int percent, string Message)
        {
            if (Operations_PB.InvokeRequired)
            {
                NotifyCallback d = new NotifyCallback(Notify);
                this.Invoke(d, new object[] { percent, Message });
            }
            else
            {
                Operations_PB.Value = percent;
                Operations_L.Text = Message;
            }
        }
        public void SetMaximum(int Max)
        {
            Operations_PB.Invoke((MethodInvoker)delegate ()
            {
                Operations_PB.Maximum = Max;
            });
        }

        private void ForLongOperations_F_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        public void CloseAsync()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.Close();
            });
        }
    }
}
