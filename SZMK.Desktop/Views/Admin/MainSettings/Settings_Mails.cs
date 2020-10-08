using Equin.ApplicationFramework;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.Views.Admin.MainSettings
{
    public partial class Settings_Mails : Form
    {
        public Settings_Mails()
        {
            InitializeComponent();
        }

        BindingListView<Mail> View;

        private void Display(List<Mail> List)
        {
            View = new BindingListView<Mail>(List);
            Mails_DGV.DataSource = View;
        }

        private bool AddMail()
        {
            try
            {
                Registration_Mail Dialog = new Registration_Mail();

                DateTime DateCreate = DateTime.Now;
                Dialog.DataReg_TB.Text = DateCreate.ToShortDateString();

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Int64 Index = -1;

                    using (var Connect = new NpgsqlConnection(SystemArgs.DataBase.ToString()))
                    {
                        Connect.Open();

                        using (var Command = new NpgsqlCommand($"SELECT last_value FROM \"AllMail_ID_seq\"", Connect))
                        {
                            using (var Reader = Command.ExecuteReader())
                            {
                                while (Reader.Read())
                                {
                                    Index = Reader.GetInt64(0);
                                }
                            }
                        }
                    }

                    Mail Temp = new Mail(Index + 1, Dialog.Name_TB.Text, Dialog.MiddleName_TB.Text, Dialog.Surname_TB.Text, DateCreate, Dialog.AddressMail_TB.Text);

                    if (SystemArgs.Request.AddMail(Temp))
                    {
                        SystemArgs.Mails.Add(Temp); return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            if (AddMail())
            {
                Display(SystemArgs.Mails);
            }
        }

        private bool ChangeMail()
        {
            try
            {
                if (Mails_DGV.CurrentCell.RowIndex >= 0)
                {
                    Mail Temp = (Mail)View[Mails_DGV.CurrentCell.RowIndex];

                    Registration_Mail Dialog = new Registration_Mail();

                    Dialog.label1.Text = "Изменение адреса электронной почты";

                    Dialog.DataReg_TB.Text = Temp.DateCreate.ToShortDateString();
                    Dialog.Name_TB.Text = Temp.Name;
                    Dialog.MiddleName_TB.Text = Temp.MiddleName;
                    Dialog.Surname_TB.Text = Temp.Surname;
                    Dialog.AddressMail_TB.Text = Temp.MailAddress;

                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {
                        Mail NewMail = new Mail(Temp.ID, Dialog.Name_TB.Text, Dialog.MiddleName_TB.Text, Dialog.Surname_TB.Text, Temp.DateCreate, Dialog.AddressMail_TB.Text);

                        if (SystemArgs.Request.ChangeMail(NewMail))
                        {
                            SystemArgs.Mails.Remove(Temp);
                            SystemArgs.Mails.Add(NewMail);

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать объект");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Change_B_Click(object sender, EventArgs e)
        {
            if (ChangeMail())
            {
                Display(SystemArgs.Mails);
            }
        }

        private bool DeleteMail()
        {
            try
            {
                if (Mails_DGV.CurrentCell.RowIndex >= 0)
                {
                    Mail Temp = (Mail)View[Mails_DGV.CurrentCell.RowIndex];

                    if (MessageBox.Show("Вы действительно хотите удалить адрес электронной почты?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (SystemArgs.Request.DeleteMail(Temp))
                        {
                            SystemArgs.Mails.Remove(Temp);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать объект");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if (DeleteMail())
            {
                Display(SystemArgs.Mails);

                if (SystemArgs.Mails.Count <= 0)
                {
                    Delete_B.Enabled = false;
                    Change_B.Enabled = false;
                }
            }
        }

        private void MoreInfo_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mails_DGV.CurrentCell.RowIndex >= 0)
                {
                    Mail Temp = (Mail)View[Mails_DGV.CurrentCell.RowIndex];

                    Information_Mail Dialog = new Information_Mail();

                    Dialog.DataReg_TB.Text = Temp.DateCreate.ToShortDateString();
                    Dialog.Name_TB.Text = Temp.Name;
                    Dialog.Surname_TB.Text = Temp.Surname;
                    Dialog.MiddleName_TB.Text = Temp.MiddleName;
                    Dialog.ID_TB.Text = Temp.ID.ToString();
                    Dialog.AddressMail_TB.Text = Temp.MailAddress;

                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать объект");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        List<Mail> Result;

        private void ResetSearch()
        {
            if (Result != null)
            {
                Search_TB.Text = String.Empty;

                Result.Clear();
            }
        }

        private List<Mail> ResultSearch(String TextSearch)
        {
            List<Mail> Result = new List<Mail>();

            if (!String.IsNullOrEmpty(TextSearch))
            {
                foreach (Mail Temp in SystemArgs.Mails)
                {
                    if (Temp.SearchString().IndexOf(TextSearch) != -1)
                    {
                        Result.Add(Temp);
                    }
                }
            }

            SystemArgs.PrintLog("Перебор значений по заданным параметрам успешно завершен");

            return Result;
        }

        private bool Search()
        {
            try
            {
                if (!String.IsNullOrEmpty(Search_TB.Text))
                {
                    String SearchText = Search_TB.Text.Trim();

                    Result = ResultSearch(SearchText);

                    if (Result.Count <= 0)
                    {
                        Search_TB.Focus();
                        MessageBox.Show("Поиск не дал результатов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SystemArgs.PrintLog("Количество объектов по параметрам поиска 0");
                        return false;
                    }

                    return true;
                }
                else
                {
                    ResetSearch();
                    SystemArgs.PrintLog("Получено пустое значение параметра поиска");
                    return false;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Search_B_Click(object sender, EventArgs e)
        {
            if (Search())
            {
                if (Result != null)
                {
                    Display(Result);
                }
            }
        }

        private void Selection(bool flag)
        {
            if (flag)
            {
                Mails_DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Выделение строки

                Change_B.Enabled = true;
                Delete_B.Enabled = true;
                MoreInfo_B.Enabled = true;
            }
            else
            {
                Change_B.Enabled = false;
                Delete_B.Enabled = false;
                MoreInfo_B.Enabled = false;
            }
        }

        private void ResetSearch_B_Click(object sender, EventArgs e)
        {
            ResetSearch();
            Display(SystemArgs.Mails);
        }

        private void SettingsMails_F_Load(object sender, EventArgs e)
        {

            Change_B.Enabled = false;
            Delete_B.Enabled = false;
            MoreInfo_B.Enabled = false;

            Display(SystemArgs.Mails);
            Mails_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Mails_DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (Mails_DGV.CurrentCell != null && Mails_DGV.CurrentCell.RowIndex < View.Count())
            {
                Selection(true);
            }
            else
            {
                Selection(false);
            }
        }

        private void Server_B_Click(object sender, EventArgs e)
        {
            Settings_ServerMail Dialog = new Settings_ServerMail();

            Dialog.Login_TB.Text = SystemArgs.ServerMail.Login;
            Dialog.Name_TB.Text = SystemArgs.ServerMail.Name;
            Dialog.NameWho_TB.Text = SystemArgs.ServerMail.NameWho;
            Dialog.Password_TB.Text = SystemArgs.ServerMail.Password;
            Dialog.Port_TB.Text = SystemArgs.ServerMail.Port;
            Dialog.SMTP_TB.Text = SystemArgs.ServerMail.SMTP;
            Dialog.TestEmail_TB.Text = SystemArgs.ServerMail.TestUser;
            Dialog.SSL_CB.Checked = SystemArgs.ServerMail.SSL;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Mails_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(112, 238, 226);
            e.CellStyle.SelectionForeColor = Color.Black;
        }

        private void SettingsMails_F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl == Search_TB)
            {
                Search_B.PerformClick();
            }
        }

        private void ADSettingsMails_F_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Refresh_B_Click(object sender, EventArgs e)
        {
            List<Mail> Temp = null;

            try
            {
                Temp = new List<Mail>(SystemArgs.Mails);

                SystemArgs.Mails.Clear();

                SystemArgs.Request.GetAllMails();

                Display(SystemArgs.Mails);
            }
            catch (Exception E)
            {
                if (Temp != null)
                {
                    Display(Temp);
                }

                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneralConstructor_B_Click(object sender, EventArgs e)
        {
            Settings_GeneralConstructor Dialog = new Settings_GeneralConstructor();

            Dialog.Email_TB.Text = SystemArgs.ServerMail.EmailGeneralConstructor;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SystemArgs.ServerMail.EmailGeneralConstructor = Dialog.Email_TB.Text.Trim();

                if (SystemArgs.ServerMail.SetEmailGeneralConstructor())
                {
                    MessageBox.Show("Успешное сохранение!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
