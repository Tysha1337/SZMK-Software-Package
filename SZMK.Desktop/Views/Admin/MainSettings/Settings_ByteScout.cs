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

namespace SZMK.Desktop.Views.Admin.MainSettings
{
    public partial class Settings_ByteScout : Form
    {
        public Settings_ByteScout()
        {
            InitializeComponent();
        }

        private void SaveDirectoryProgPath_B_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(IP_TB.Text))
                {
                    IP_TB.Focus();
                    throw new Exception("Необходимо ввести адрес программы распознавания");
                }

                if (String.IsNullOrEmpty(Port_TB.Text))
                {
                    Port_TB.Focus();
                    throw new Exception("Необходимо ввести порт программы распознавания");
                }

                Int32 Port = Convert.ToInt32(Port_TB.Text);

                SystemArgs.ByteScout.Server = IP_TB.Text.Trim();
                SystemArgs.ByteScout.Port = Port_TB.Text.Trim();

                if (SystemArgs.ByteScout.CheckConnect())
                {
                    if (SystemArgs.ByteScout.SetParametersConnect())
                    {
                        MessageBox.Show("Параметры успешно записаны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception("Ошибка при записи директорий");
                    }
                }
                else
                {
                    throw new Exception("Ошибка при подключении к серверу распознавания");
                }
            }
            catch (FormatException)
            {
                Port_TB.Focus();
                MessageBox.Show("Порт подключения должен состоять из целых цифр", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ADSettingsByteScout_F_Load(object sender, EventArgs e)
        {

        }
    }
}
