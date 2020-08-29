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
    public partial class Registration_Mail : Form
    {
        public Registration_Mail()
        {
            InitializeComponent();
        }

        private void RegistrationMail_Load(object sender, EventArgs e)
        {

        }

        private void RegistrationMail_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                try
                {
                    if (String.IsNullOrEmpty(DataReg_TB.Text))
                    {
                        DataReg_TB.Focus();
                        throw new Exception("Необходимо указать дату регистрации электронной почты");
                    }

                    if (String.IsNullOrEmpty(Name_TB.Text))
                    {
                        Name_TB.Focus();
                        throw new Exception("Необходимо указать имя владельца почты");
                    }

                    if (String.IsNullOrEmpty(Surname_TB.Text))
                    {
                        Surname_TB.Focus();
                        throw new Exception("Необходимо указать фамилию владельца почты");
                    }

                    if (String.IsNullOrEmpty(MiddleName_TB.Text))
                    {
                        MiddleName_TB.Focus();
                        throw new Exception("Необходимо указать отчество владельца почты");
                    }

                    if (String.IsNullOrEmpty(AddressMail_TB.Text))
                    {
                        AddressMail_TB.Focus();
                        throw new Exception("Необходимо указать адрес почты");
                    }

                    if (AddressMail_TB.Text.Trim().IndexOf('@') == -1)
                    {
                        AddressMail_TB.Focus();
                        throw new Exception("Неверный формат почты");
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }
    }
}
