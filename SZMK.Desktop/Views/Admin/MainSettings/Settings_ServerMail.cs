using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.Admin.MainSettings
{
    public partial class Settings_ServerMail : Form
    {
        public Settings_ServerMail()
        {
            InitializeComponent();
        }

        private void Save_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(NameWho_TB.Text))
                {
                    NameWho_TB.Focus();
                    throw new Exception("Необходимо ввести отправителя");
                }

                if (String.IsNullOrEmpty(SMTP_TB.Text))
                {
                    SMTP_TB.Focus();
                    throw new Exception("Необходимо ввести SMTP - сервер");
                }

                if (String.IsNullOrEmpty(Port_TB.Text))
                {
                    Port_TB.Focus();
                    throw new Exception("Необходимо ввести порт");
                }

                Int32 Port = Convert.ToInt32(Port_TB.Text);

                if (String.IsNullOrEmpty(Name_TB.Text))
                {
                    Name_TB.Focus();
                    throw new Exception("Необходимо ввести имя");
                }

                if (String.IsNullOrEmpty(Login_TB.Text))
                {
                    Login_TB.Focus();
                    throw new Exception("Необходимо ввести логин");
                }

                if (String.IsNullOrEmpty(Password_TB.Text))
                {
                    Password_TB.Focus();
                    throw new Exception("Необходимо ввести пароль");
                }

                if (String.IsNullOrEmpty(TestEmail_TB.Text))
                {
                    Password_TB.Focus();
                    throw new Exception("Необходимо ввести тестового получателя");
                }

                if (SystemArgs.ServerMail.CheckConnect(NameWho_TB.Text.Trim(),Name_TB.Text.Trim(), SMTP_TB.Text.Trim(), Convert.ToInt32(Port_TB.Text.Trim()),Login_TB.Text.Trim(), Password_TB.Text.Trim(),TestEmail_TB.Text.Trim()))
                {
                    SystemArgs.ServerMail.Name = Name_TB.Text.Trim();
                    SystemArgs.ServerMail.Port = Port_TB.Text.Trim();
                    SystemArgs.ServerMail.NameWho = NameWho_TB.Text.Trim();
                    SystemArgs.ServerMail.Login = Login_TB.Text.Trim();
                    SystemArgs.ServerMail.SMTP = SMTP_TB.Text.Trim();
                    SystemArgs.ServerMail.Password = Password_TB.Text.Trim();
                    SystemArgs.ServerMail.TestUser = TestEmail_TB.Text.Trim();
                    SystemArgs.ServerMail.SSL = SSL_CB.Checked;

                    if (SystemArgs.ServerMail.SetParametersConnect())
                    {
                        MessageBox.Show("Параметры подключения к почтовому серверу успешно записаны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception("Ошибка при записи параметров подключения к почтовому серверу");
                    }
                }
                else
                {
                    throw new Exception("Ошибка при попытке подключения к почтовому серверу. Отмена записи параметров");
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

        private void OK_B_Click(object sender, EventArgs e)
        {

        }
    }
}
