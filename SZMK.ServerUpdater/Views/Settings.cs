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

namespace SZMK.ServerUpdater.Views
{
    public partial class Settings : Form, IBaseView
    {
        OperationsFiles operationsFiles;

        public Settings(OperationsFiles operationsFiles)
        {
            InitializeComponent();
            this.operationsFiles = operationsFiles;
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
            catch (FormatException)
            {
                Error("Порт должен быть целым числом");
                e.Cancel = true;
            }
        }

        private void SettingsFiles_B_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsFiles files = new SettingsFiles();

                files.Files_DGV.AutoGenerateColumns = false;

                files.Files_DGV.DataSource = operationsFiles.GetSettingsUpdate();

                if (files.ShowDialog() == DialogResult.OK)
                {
                    operationsFiles.FormingSettingsUpdate((List<LastUpdateFiles>)files.Files_DGV.DataSource);
                }
            }
            catch (Exception Ex)
            {
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
