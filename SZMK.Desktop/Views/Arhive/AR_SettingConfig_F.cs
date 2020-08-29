using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.Arhive
{
    public partial class AR_SettingConfig_F : Form
    {
        public AR_SettingConfig_F()
        {
            InitializeComponent();
        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(ArchivePath_TB.Text))
                {
                    ArchivePath_TB.Focus();
                    throw new Exception("Необходимо указать директорию архива");
                }

                if (!Directory.Exists(ArchivePath_TB.Text.Trim()))
                {
                    ArchivePath_TB.Focus();
                    throw new Exception("Указанная дирекория архива не существует");
                }

                SystemArgs.SettingsUser.ArchivePath = ArchivePath_TB.Text.Trim();

                if (SystemArgs.SettingsUser.SetParametersConnect())
                {
                    MessageBox.Show("Параметры успешно записаны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Ошибка при записи параметров");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + ". Запись не выполнена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReviewArchive_B_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Ofd = new FolderBrowserDialog();

            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                ArchivePath_TB.Text = Ofd.SelectedPath;
            }
        }
    }
}
