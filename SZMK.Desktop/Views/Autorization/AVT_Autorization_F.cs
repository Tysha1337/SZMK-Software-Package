using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.Desktop.Models;
using SZMK.Desktop.Services;
using SZMK.Desktop.Services.Setting;
using SZMK.Desktop.Views.Admin;
using SZMK.Desktop.Views.Arhive;
using SZMK.Desktop.Views.Chief_PDO;
using SZMK.Desktop.Views.Design_Engineer;
using SZMK.Desktop.Views.KB;
using SZMK.Desktop.Views.OPP;
using SZMK.Desktop.Views.PDO;

namespace SZMK.Desktop.Views.Autorization
{
    public partial class AVT_Autorization_F : Form
    {
        public AVT_Autorization_F()
        {
            InitializeComponent();
        }

        private bool UpdatePassword(Models.User User)
        {
            String Password = String.Empty;

            AVT_ChangePassword_F Dialog = new AVT_ChangePassword_F();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Password = Hash.GetSHA256(Dialog.NewPassword_TB.Text.Trim());

                if (SystemArgs.Request.UpdatePasswordText(Password, User))
                {
                    if (SystemArgs.Request.UpdatePassword(User, true))
                    {
                        Int32 Index = SystemArgs.Users.FindIndex(p => p.ID == User.ID);

                        SystemArgs.Users[Index].UpdPassword = true;
                        SystemArgs.Users[Index].HashPassword = Password;

                        SystemArgs.User = null;

                        return true;
                    }
                    else
                    {
                        throw new Exception("Обнаружена ошибка при обновлении пароля");
                    }
                }
            }

            return false;
        }

        private void Enter_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Login_CB.Text.Trim()))
                {
                    Models.User User = SearchUser(Login_CB.Text.Trim());

                    if (User != null)
                    {
                        String Password = Password_TB.Text.Trim();

                        if (ComparePassword(User, Hash.GetSHA256(Password)))
                        {
                            SystemArgs.User = User;

                            if(SystemArgs.User.UpdPassword)
                            {
                                SaveData();
                                Start(User);
                            }
                            else
                            {
                                if(UpdatePassword(SystemArgs.User))
                                {
                                    MessageBox.Show("Пароль успешно изменен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Обнаружена ошибка при вводе логина или пароля");
                        }
                    }
                    else
                    {
                        throw new Exception("Пользователь не существует");
                    }
                }
                else
                {
                    throw new Exception("Пользователь не выбран");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void SaveData()
        {
            XDocument xdoc = XDocument.Load(SystemArgs.Path.UserAvtorizationPath);
            xdoc.Element("Avtorization").Element("SaveData").SetValue(SaveData_CB.Checked.ToString());
            xdoc.Element("Avtorization").Element("Login").SetValue(Login_CB.SelectedValue.ToString());
            xdoc.Element("Avtorization").Element("Password").SetValue(Hash.GetSHA256(Password_TB.Text));
            xdoc.Save(SystemArgs.Path.UserAvtorizationPath);
        }

        private void Start(Models.User User)
        {
            Models.Position Position = User.GetPosition();

            if(Position != null)
            {
                Int64 IDPosition = Position.ID;

                switch(IDPosition)
                {
                    case 1: //Администратор
                        Main Administrator = new Main();
                        this.Hide();
                        Tray.Visible = false;
                        Administrator.Show();
                        break;
                    case 2: //Инженер конструктор
                        Design_Engineer_F Design_Engineer = new Design_Engineer_F();
                        this.Hide();
                        if (SystemArgs.SettingsUser.Hidden)
                        {
                            Design_Engineer.WindowState = FormWindowState.Minimized;
                            Design_Engineer.ShowInTaskbar = false;
                        }
                        Tray.Visible = false;
                        Design_Engineer.Show();
                        break;
                    case 3: //КБ
                        KB_F KB = new KB_F();
                        this.Hide();
                        Tray.Visible = false;
                        KB.Show();
                        break;
                    case 4: //Архивариус
                        AR_Arhive_F Arhive = new AR_Arhive_F();
                        this.Hide();
                        Tray.Visible = false;
                        Arhive.Show();
                        break;
                    case 5://Сотрудник ПДО
                        PDO_F PDO = new PDO_F();
                        this.Hide();
                        Tray.Visible = false;
                        PDO.Show();
                        break;
                    case 6://Сотрудник ОПП
                        OPP_F OPP = new OPP_F();
                        this.Hide();
                        Tray.Visible = false;
                        OPP.Show();
                        break;
                    case 7:
                        Chief_PDO_F Chief_PDO = new Chief_PDO_F();
                        this.Hide();
                        Tray.Visible = false;
                        Chief_PDO.Show();
                        break;
                    default:
                        throw new Exception("Должности пользователя не существует");
                }
            }
        }

        private Models.User SearchUser(String Login)
        {
            foreach (Models.User Temp in SystemArgs.Users)
            {
                if (Temp.Login == Login)
                {
                    return Temp;
                }
            }

            return null;
        }

        private bool ComparePassword(Models.User User, String Password)
        {
            if (User.HashPassword == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Autorization_F_Load(object sender, EventArgs e)
        {
            try
            {
                SystemArgs.Sleep = new Sleep();
                SystemArgs.Sleep.Start();

                SystemArgs.Path = new Services.Setting.Path(); //Системные пути
                SystemArgs.SettingsProgram = new Services.Setting.Program();

                if (SystemArgs.SettingsProgram.CheckedProcess)
                {
                    if (Process.GetProcessesByName("SZMK").Length > 1)
                    {
                        MessageBox.Show("Открыто более одного экземпляра программы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }

                SystemArgs.DataBase = new DataBase(); //Конфигурация базы данных
                SystemArgs.Request = new Request(); //Слой запросов к базе данных

                if (!SystemArgs.DataBase.CheckConnect(SystemArgs.DataBase.ToString()))
                {
                    MessageBox.Show("Отсутствует соединение с базой данных. Работа программного обеспечения приостановлена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                SystemArgs.RequestLinq = new RequestLinq(); //Слой запросов linq к полученным данным из БД
                SystemArgs.About = new AboutProgram();

                Password_TB.UseSystemPasswordChar = true;

                List<Models.User> Users = new List<Models.User>();
                SystemArgs.Users = new List<Models.User>(); //Список всех пользователей в программе
                SystemArgs.Positions = new List<Models.Position>(); //Общий список должностей
                SystemArgs.Request.GetAllPositions();
                SystemArgs.Mails = new List<Mail>(); //Общий список адресов почты
                SystemArgs.Request.GetAllMails();
                SystemArgs.Statuses = new List<Status>();
                SystemArgs.TypesAdds = new List<TypeAdd>();
                SystemArgs.Models = new List<Model>();

                SystemArgs.SettingsUser = new Services.Setting.User();
                SystemArgs.SettingsPosition = new Services.Setting.Position();

                SystemArgs.Request.GetAllTypesAdd();
                SystemArgs.Request.GetAllStatus();
                SystemArgs.Request.GetAllUsers();

                Users.Add(new Models.User(-1, "Не выбрано", "Нет отчества", "Нет фамилии", DateTime.Now, 1, new List<Mail>(), "Не выбрано", "Нет хеша", true));
                Users.AddRange(SystemArgs.Users.OrderBy(p=>p.Login));
                Login_CB.DataSource = Users;
                AutoLoginAsync();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void CheckPass_CB_CheckedChanged(object sender, EventArgs e)
        {
            Password_TB.UseSystemPasswordChar = !Password_TB.UseSystemPasswordChar;
        }

        private void Autorization_F_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Cancel_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Autorization_F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enter_B.PerformClick();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                Cancel_B.PerformClick();
            }
        }
        bool StopThread = false;
        private async Task AutoLoginAsync()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.UserAvtorizationPath))
                {
                    throw new Exception();
                }

                XDocument xdoc = XDocument.Load(SystemArgs.Path.UserAvtorizationPath);

                if (xdoc.Element("Avtorization").Element("SaveData").Value == "True")
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    Tray.ShowBalloonTip(5);
                    SaveData_CB.Checked = true;
                    Login_CB.Text = xdoc.Element("Avtorization").Element("Login").Value;
                    Password_TB.Text = xdoc.Element("Avtorization").Element("Password").Value;
                    Login_CB.Enabled = false;
                    Password_TB.Enabled = false;
                    CheckPass_CB.Enabled = false;
                    Enter_B.Text = "Отмена(" + (5 - Second) + ")";
                    await Task.Run(() => AutoLogin());
                    if (!StopThread)
                    {
                        if (!String.IsNullOrEmpty(Login_CB.Text.Trim()))
                        {
                            Models.User User = SearchUser(Login_CB.Text.Trim());

                            if (User != null)
                            {
                                String Password = Password_TB.Text.Trim();

                                if (ComparePassword(User, Password))
                                {
                                    SystemArgs.User = User;

                                    if (SystemArgs.User.UpdPassword)
                                    {
                                        Start(User);
                                    }
                                    else
                                    {
                                        if (UpdatePassword(SystemArgs.User))
                                        {
                                            DefaultLogin();
                                            MessageBox.Show("Пароль успешно изменен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception("Обнаружена ошибка при вводе логина или пароля");
                                }
                            }
                            else
                            {
                                throw new Exception("Пользователь не существует");
                            }
                        }
                        else
                        {
                            throw new Exception("Пользователь не выбран");
                        }
                    }
                    else
                    {
                        DefaultLogin();
                    }
                    
                }
            }
            catch (Exception E)
            {
                DefaultLogin();
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DefaultLogin()
        {
            Enter_B.Text = "Войти";
            CheckPass_CB.Enabled = true;
            Login_CB.Enabled = true;
            Password_TB.Clear();
            Password_TB.Enabled = true;
        }
        int Second = 0;
        private void AutoLogin()
        {
            try
            {
                Enter_B.Click -= Enter_B_Click;
                Enter_B.Click += Stop_B_Click;
                System.Timers.Timer aTimer = new System.Timers.Timer(1000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Start();
                while (Second < 5 && !StopThread)
                {

                }
                aTimer.Stop();
                Enter_B.Click -= Stop_B_Click;
                Enter_B.Click += Enter_B_Click;
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Second++;
            Enter_B.Invoke((MethodInvoker)delegate ()
            {
                Enter_B.Text = "Отмена(" + (5 - Second) + ")";
            });
        }

        private void Stop_B_Click(object sender, EventArgs e)
        {
            try
            {
                StopThread = true;
                DefaultLogin();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
