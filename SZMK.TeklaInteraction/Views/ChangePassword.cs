using NLog;
using System;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Views.Interfaces;

namespace SZMK.TeklaInteraction.Views
{
    public partial class ChangePassword : Form, IChangePassword
    {
        private readonly Logger logger;

        public event Action UpdatePassword;

        public string OldPassword { get { return OldPassword_TB.Text; } }
        public string NewPassword { get { return NewPassword_TB.Text; } }
        public string ComparePassword { get { return ComparePassword_TB.Text; } }

        public ChangePassword()
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                InitializeComponent();

                logger.Info("Инициализация обновления пароля успешна");
            }
            catch
            {
                Error("Ошибка инициализации обновления пароля");
            }
        }

        public new void Show()
        {
            ShowDialog();
        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            UpdatePassword?.Invoke();
        }

        private void Cancel_B_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void CheckPass_CB_CheckedChanged(object sender, EventArgs e)
        {
            ViewPass(!CheckPass_CB.Checked);
        }
        private void ViewPass(bool View)
        {
            OldPassword_TB.UseSystemPasswordChar = View;
            NewPassword_TB.UseSystemPasswordChar = View;
            ComparePassword_TB.UseSystemPasswordChar = View;
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Info("Закончено обновление пароля");
        }
    }
}
