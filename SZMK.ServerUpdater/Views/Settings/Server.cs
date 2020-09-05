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
using SZMK.ServerUpdater.Models;
using SZMK.ServerUpdater.Services;
using SZMK.ServerUpdater.Views.Interfaces;

namespace SZMK.ServerUpdater.Views.Settings
{
    public partial class Server : Form, IBaseView
    {
        private readonly Logger logger;

        OperationsFiles operationsFiles;

        public Server(OperationsFiles operationsFiles)
        {
            InitializeComponent();

            logger = LogManager.GetCurrentClassLogger();

            this.operationsFiles = operationsFiles;

            logger.Info("Инициализация формы настройки сервера пройдена успешно");
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    int Port = Convert.ToInt32(Port_TB.Text);
                }
            }
            catch (FormatException FormEx)
            {
                Error(FormEx);
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
    }
}
