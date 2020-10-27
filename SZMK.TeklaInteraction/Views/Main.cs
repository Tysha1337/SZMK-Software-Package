using NLog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Views.Interfaces;

namespace SZMK.TeklaInteraction.Views
{
    public partial class Main : Form, IMain
    {
        private readonly ApplicationContext _context;
        private readonly Logger logger;

        public event Action StartedProgram;
        public event Action LoadSettings;
        public event Action SaveSettings;
        public event Action StoppedChecker;
        public event Action ResetAll;
        public event Action Reset21_1;
        public event Action Reset2018;
        public event Action Reset2017;

        public string Email { get { return Email_TB.Text; } set { Email_TB.Text = value; } }
        public string Login { get { return Login_TB.Text; } set { Login_TB.Text = value; } }
        public string UserName { get { return Name_TB.Text; } set { Name_TB.Text = value; } }
        public string Password { get { return Password_TB.Text; } set { Password_TB.Text = value; } }
        public string Host { get { return Host_TB.Text; } set { Host_TB.Text = value; } }
        public int Port { get { return Convert.ToInt32(Port_TB.Text); } set { Port_TB.Text = value.ToString(); } }
        public bool SSL { get { return SSL_CB.Checked; } set { SSL_CB.Checked = value; } }

        public string NameDB { get { return NameDB_TB.Text; } set { NameDB_TB.Text = value; } }
        public string OwnerDB { get { return OwnerDB_TB.Text; } set { OwnerDB_TB.Text = value; } }
        public string PortDB { get { return PortDB_TB.Text; } set { PortDB_TB.Text = value; } }
        public string IPDB { get { return IPDB_TB.Text; } set { IPDB_TB.Text = value; } }
        public string PasswordDB { get { return PasswordDB_DB.Text; } set { PasswordDB_DB.Text = value; } }

        public bool CheckedMarks { get { return CheckedMarks_CB.Checked; } set { CheckedMarks_CB.Checked = value; } }

        public string LoginUser
        {
            get
            {
                string Temp = "";
                LoginUser_CB.Invoke((MethodInvoker)delegate ()
                {
                    Temp = LoginUser_CB.Text;
                });
                return Temp;
            }
            set
            {
                LoginUser_CB.Invoke((MethodInvoker)delegate ()
                {
                    LoginUser_CB.Text = value;
                });
            }
        }
        public string PasswordUser { get { return PasswordUser_TB.Text; } set { PasswordUser_TB.Text = value; } }

        public Main(ApplicationContext context)
        {
            try
            {
                _context = context;
                logger = LogManager.GetCurrentClassLogger();

                InitializeComponent();

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;

                logger.Info("Инициализация успешна");
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
        public void OpenView()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        public void LoadOperation(string Message)
        {
            Operations_TB.Invoke((MethodInvoker)delegate ()
            {
                Operations_TB.AppendText(Message + Environment.NewLine);
            });
        }
        public void ClearPassword()
        {
            PasswordUser_TB.Invoke((MethodInvoker)delegate ()
            {
                PasswordUser_TB.Clear();
            });
        }
        public void ShowUsers(List<User> users)
        {
            LoginUser_CB.Invoke((MethodInvoker)delegate ()
            {
                LoginUser_CB.DataSource = users;
            });
        }
        public void FocusAuth()
        {
            Main_TC.SelectedIndex = 1;
            Settings_TC.SelectedIndex = 3;
        }
        public void Error(string Message)
        {
            logger.Error(Message);
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Info(string Message)
        {
            logger.Info(Message);
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warning(string Message)
        {
            logger.Warn(Message);
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            StartedProgram?.Invoke();
        }

        private void Save_B_Click(object sender, EventArgs e)
        {
            SaveSettings?.Invoke();
        }

        private void Main_TC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Main_TC.SelectedIndex == 1)
            {
                LoadSettings?.Invoke();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tray.ShowBalloonTip(5);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            e.Cancel = true;
            logger.Info("Tekla_Interaction свернута в трей");
        }

        private void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            logger.Info("Tekla_Interaction развернута из трея");
        }

        private void Close_TSM_Click(object sender, EventArgs e)
        {
            logger.Info("Tekla_Interaction закрыта");
            StoppedChecker?.Invoke();
            Environment.Exit(0);
        }

        private void Open_TSM_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            logger.Info("Tekla_Interaction развернута из трея");
        }

        private void ResetAll_TSM_Click(object sender, EventArgs e)
        {
            ResetAll?.Invoke();
        }

        private void Reset21_1_TSM_Click(object sender, EventArgs e)
        {
            Reset21_1?.Invoke();
        }

        private void Reset2018_TSM_Click(object sender, EventArgs e)
        {
            Reset2018?.Invoke();
        }

        private void Reset2017_TSM_Click(object sender, EventArgs e)
        {
            Reset2017?.Invoke();
        }
    }
}
