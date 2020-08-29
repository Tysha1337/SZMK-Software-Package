using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Services;

namespace SZMK.Desktop.Views.Autorization
{
    public partial class AVT_ChangePassword_F : Form
    {
        public AVT_ChangePassword_F()
        {
            InitializeComponent();
        }

        private void AVTChangePassword_F_Load(object sender, EventArgs e)
        {

        }

        private void AVTChangePassword_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    if (String.IsNullOrEmpty(OldPassword_TB.Text))
                    {
                        OldPassword_TB.Focus();
                        throw new Exception("Необходимо указать старый пароль");
                    }

                    if (String.IsNullOrEmpty(NewPassword_TB.Text))
                    {
                        NewPassword_TB.Focus();
                        throw new Exception("Необходимо указать новый пароль");
                    }

                    if (String.IsNullOrEmpty(ComparePassword_TB.Text))
                    {
                        ComparePassword_TB.Focus();
                        throw new Exception("Необходимо повторно указать новый пароль");
                    }

                    String Old = Hash.GetSHA256(OldPassword_TB.Text.Trim());

                    if(SystemArgs.User.HashPassword != Old)
                    {
                        OldPassword_TB.Focus();
                        throw new Exception("Указан неверный старый пароль");
                    }

                    String New = NewPassword_TB.Text.Trim();
                    String Compare = ComparePassword_TB.Text.Trim();

                    if (New != Compare)
                    {
                        NewPassword_TB.Focus();
                        throw new Exception("Укзанные пароли не совпадают");
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void CheckPass_CB_CheckedChanged(object sender, EventArgs e)
        {
            OldPassword_TB.UseSystemPasswordChar = !OldPassword_TB.UseSystemPasswordChar;
            NewPassword_TB.UseSystemPasswordChar = !NewPassword_TB.UseSystemPasswordChar;
            ComparePassword_TB.UseSystemPasswordChar = !ComparePassword_TB.UseSystemPasswordChar;
        }
    }
}
