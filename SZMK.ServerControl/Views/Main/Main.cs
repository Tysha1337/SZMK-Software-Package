using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.ServerControl.Views.Main.Interface;

namespace SZMK.ServerControl.Views.Main
{
    public partial class Main : Form, IMain
    {
        private readonly ApplicationContext _context;

        public event Action SettingsServer;

        public Main(ApplicationContext context)
        {
            try
            {
                _context = context;

                InitializeComponent();
            }
            catch
            {
                Error("Ошибка инициализации программы");
                this.Close();
            }
        }

        public new void Show()
        {
            try
            {
                _context.MainForm = this;

                Application.Run(_context);
            }
            catch
            {
                Error("Ошибка запуска программы");
                this.Close();
            }
        }

        public void Error(string Message)
        {
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Info(string Message)
        {
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Warning(string Message)
        {
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SettingsServer_TSM_Click(object sender, EventArgs e)
        {
            SettingsServer?.Invoke();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
