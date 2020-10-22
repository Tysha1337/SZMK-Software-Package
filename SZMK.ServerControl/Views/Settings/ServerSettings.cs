using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.ServerControl.Views.Settings.Interfaces;

namespace SZMK.ServerControl.Views.Settings
{
    public partial class ServerSettings : Form, IServerSettings
    {
        public event Action LoadSettings;

        public string IP { get => IP_TB.Text; set => IP_TB.Text=value; }
        public int Port { get => Convert.ToInt32(Port_TB.Text); set => Port_TB.Text = value.ToString(); }

        public ServerSettings()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                this.Close();
            }
        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ServerSettings_Load(object sender, EventArgs e)
        {
            LoadSettings?.Invoke();

            INotifyPropertyChanged
        }
    }
}
