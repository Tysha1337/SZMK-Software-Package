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
    public partial class Settings_DataBase : Form
    {
        public Settings_DataBase()
        {
            InitializeComponent();
        }

        private void Save_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Server_TB.Text))
                {
                    Server_TB.Focus();
                    throw new Exception("Необходимо ввести сервер базы данных");
                }

                if (String.IsNullOrEmpty(Port_TB.Text))
                {
                    Port_TB.Focus();
                    throw new Exception("Необходимо ввести порт");
                }

                Int32 Port = Convert.ToInt32(Port_TB.Text);

                if (String.IsNullOrEmpty(Owner_TB.Text))
                {
                    Owner_TB.Focus();
                    throw new Exception("Необходимо ввести владельца базы данных");
                }

                if (String.IsNullOrEmpty(Password_TB.Text))
                {
                    Password_TB.Focus();
                    throw new Exception("Необходимо ввести пароль базы данных");
                }

                if (String.IsNullOrEmpty(Name_TB.Text))
                {
                    Name_TB.Focus();
                    throw new Exception("Необходимо ввести наименование базы данных");
                }

                String ConnectString = $@"Server = {Server_TB.Text.Trim()}; Port = {Port_TB.Text.Trim()}; User Id = {Owner_TB.Text.Trim()}; Password = {Password_TB.Text.Trim()}; Database = {Name_TB.Text.Trim()};";
                
                if(SystemArgs.DataBase.CheckConnect(ConnectString))
                {
                    SystemArgs.DataBase.IP = Server_TB.Text.Trim();
                    SystemArgs.DataBase.Port = Port_TB.Text.Trim();
                    SystemArgs.DataBase.Owner = Owner_TB.Text.Trim();
                    SystemArgs.DataBase.Password = Password_TB.Text.Trim();
                    SystemArgs.DataBase.Name = Name_TB.Text.Trim();

                    if (SystemArgs.DataBase.SetParametersConnect())
                    {
                        MessageBox.Show("Параметры подключения к базе данных успешно записаны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception("Ошибка при записи параметров подключения к базе данных");
                    }
                }
                else
                {
                    throw new Exception("Ошибка при попытке подключения к базе данных. Отмена записи параметров");
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

        private void ADSettingsDataBase_F_Load(object sender, EventArgs e)
        {

        }
    }
}
