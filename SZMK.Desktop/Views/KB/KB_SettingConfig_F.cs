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

namespace SZMK.Desktop.Views.KB
{
    public partial class KB_SettingConfig_F : Form
    {
        public KB_SettingConfig_F()
        {
            InitializeComponent();
        }

        private void ReviewModels_B_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Ofd = new FolderBrowserDialog();

            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                ModelsPath_TB.Text = Ofd.SelectedPath;
            }
        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(ModelsPath_TB.Text))
                {
                    ModelsPath_TB.Focus();
                    throw new Exception("Необходимо указать директорию выгрузки");
                }

                if (!Directory.Exists(ModelsPath_TB.Text.Trim()))
                {
                    ModelsPath_TB.Focus();
                    throw new Exception("Указанная дирекория выгрузки не существует");
                }

                SystemArgs.SettingsUser.ModelsPath = ModelsPath_TB.Text.Trim();

                SystemArgs.SettingsUser.TypeScan = TypesScan_CB.SelectedIndex;

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
    }
}
