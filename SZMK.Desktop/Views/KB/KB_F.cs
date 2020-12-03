using System;
using System.Drawing;
using System.Threading;
using Npgsql;
using Equin.ApplicationFramework;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Reflection;
using AForge.Video.DirectShow;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using SZMK.Desktop.Models;
using SZMK.Desktop.Views.Shared;
using SZMK.Desktop.Services.Setting;
using SZMK.Desktop.Services;
using SZMK.Desktop.BindingModels;
using SZMK.Desktop.Views.Admin;
using SZMK.Desktop.Services.Scan;
using System.IO.Ports;
using SZMK.Desktop.Views.Shared.Interfaces;
using System.ComponentModel;
using SZMK.Desktop.Services.DataGridView;
using SZMK.Desktop.Services.DataGridView.Sort;

namespace SZMK.Desktop.Views.KB
{
    public partial class KB_F : Form
    {
        public KB_F()
        {
            InitializeComponent();
        }

        SortableBindingList<Order> View;

        private bool UsedSearch = false;

        private void KB_F_Load(object sender, EventArgs e)
        {
            try
            {
                Order_DGV.AutoGenerateColumns = false;
                Order_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Order_DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                SetDoubleBuffered(Order_DGV);

                View = new SortableBindingList<Order>(new List<Order>());

                SystemArgs.MobileApplication = new MobileApplication();
                SystemArgs.ServerMail = new ServerMail();
                SystemArgs.UnLoadSpecific = new UnLoadSpecific();
                SystemArgs.Orders = new List<Order>();
                SystemArgs.BlankOrders = new List<BlankOrder>();
                SystemArgs.BlankOrderOfOrders = new List<BlankOrderOfOrder>();
                SystemArgs.StatusOfOrders = new List<StatusOfOrder>();
                SystemArgs.Excel = new Excel();
                SystemArgs.Template = new Template();
                SystemArgs.SelectedColumn = new SelectedColumn();

                ItemsFilter();
                SelectedColumnDGV();
                FilterCB_TSB.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                if (MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void AddOrder_TSB_Click(object sender, EventArgs e)
        {
            LockedButtonForLoadData(false);

            if (AddOrder())
            {
                RefreshOrderAsync(FilterCB_TSB.SelectedIndex);
            }

            LockedButtonForLoadData(true);
        }

        private void ChangeOrder_TSB_Click(object sender, EventArgs e)
        {
            if (ChangeOrder())
            {
                Display(SystemArgs.Orders);
            }
        }
        private void DeleteOrder_TSB_Click(object sender, EventArgs e)
        {
            if (DeleteOrder())
            {
                Display(SystemArgs.Orders);
            }
        }

        private void AddOrder_TSM_Click(object sender, EventArgs e)
        {
            LockedButtonForLoadData(false);

            if (AddOrder())
            {
                RefreshOrderAsync(FilterCB_TSB.SelectedIndex);
            }

            LockedButtonForLoadData(true);
        }
        private void ChangeOrder_TSM_Click(object sender, EventArgs e)
        {
            if (ChangeOrder())
            {
                Display(SystemArgs.Orders);
            }
        }

        private void DeleteOrder_TSM_Click(object sender, EventArgs e)
        {
            if (DeleteOrder())
            {
                Display(SystemArgs.Orders);
            }
        }

        private void ReportDate_TSM_Click(object sender, EventArgs e)
        {
            ReportOrderOfDate();
        }

        private void Search_TSB_Click(object sender, EventArgs e)
        {
            if (Search())
            {
                Display(SystemArgs.Orders);
            }
        }

        private void Reset_TSB_Click(object sender, EventArgs e)
        {
            ResetSearch();
        }

        private void AdvancedSearch_TSB_Click(object sender, EventArgs e)
        {
            SearchParamAsync();
        }
        private Boolean AddOrder()
        {
            try
            {
                Models.User user = SystemArgs.User;

                if (SystemArgs.SettingsPosition.SelectedUser)
                {
                    KB_SelectedUser_F selectedUser = new KB_SelectedUser_F();

                    selectedUser.Users_CB.DataSource = SystemArgs.Users.FindAll(p => p.GetPosition().ID == SystemArgs.User.GetPosition().ID);

                    if (selectedUser.ShowDialog() == DialogResult.OK)
                    {
                        user = (Models.User)selectedUser.Users_CB.SelectedItem;
                    }
                    else
                    {
                        return false;
                    }
                }

                KB_Scan_F Dialog = new KB_Scan_F();
                switch (SystemArgs.SettingsUser.TypeScan)
                {
                    case 0:
                        Dialog.Web_L.Visible = false;
                        Dialog.ViewWeb_PB.Visible = false;
                        Dialog.Main_TLP.SetRow(Dialog.Position_L, 2);
                        Dialog.Main_TLP.SetRow(Dialog.Scan_DGV, 3);
                        Dialog.Main_TLP.SetRowSpan(Dialog.Scan_DGV, 8);
                        Dialog.MaximumSize = new Size(Dialog.Width, Dialog.Height - 100);
                        Dialog.Scan_DGV.Height = Dialog.Scan_DGV.Height - 100;
                        Dialog.Status_TB.Height = Dialog.Status_TB.Height - 100;
                        SystemArgs.ScannerOrder = new ScannerOrder();//Сервер мобильного приложения
                        if (!SystemArgs.ScannerOrder.Start())
                        {
                            throw new Exception("Ошибка подключения сканера, проверьте порт");
                        }
                        break;
                    case 1:
                        SystemArgs.WebcamScanOrder = new WebcamScanOrder();
                        if (!SystemArgs.WebcamScanOrder.Start())
                        {
                            throw new Exception("Ошибка подключения вебкамеры");
                        }
                        break;
                    case 2:
                        Dialog.Web_L.Visible = false;
                        Dialog.ViewWeb_PB.Visible = false;
                        Dialog.Main_TLP.SetRow(Dialog.Position_L, 2);
                        Dialog.Main_TLP.SetRow(Dialog.Scan_DGV, 3);
                        Dialog.Main_TLP.SetRowSpan(Dialog.Scan_DGV, 8);
                        Dialog.MaximumSize = new Size(Dialog.Width, Dialog.Height - 100);
                        Dialog.Scan_DGV.Height = Dialog.Scan_DGV.Height - 100;
                        Dialog.Status_TB.Height = Dialog.Status_TB.Height - 100;
                        SystemArgs.ServerMobileAppOrder = new ServerMobileAppOrder();//Сервер мобильного приложения
                        if (!SystemArgs.ServerMobileAppOrder.Start())
                        {
                            throw new Exception("Ошибка открытия сервера для получения данных с мобильного приложения");
                        }
                        break;
                }
                Dialog.ServerStatus_TB.Text = "Запущен";
                Dialog.ServerStatus_TB.BackColor = Color.FromArgb(233, 245, 255);
                Dialog.Status_TB.AppendText($"Ожидание данных" + Environment.NewLine);

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    List<OrderScanSession> ScanSession;
                    switch (SystemArgs.SettingsUser.TypeScan)
                    {
                        case 0:
                            ScanSession = SystemArgs.ScannerOrder.GetScanSessions();
                            break;
                        case 1:
                            ScanSession = SystemArgs.WebcamScanOrder.GetScanSessions();
                            break;
                        case 2:
                            ScanSession = SystemArgs.ServerMobileAppOrder.GetScanSessions();
                            break;
                        default:
                            ScanSession = new List<OrderScanSession>();
                            break;
                    }
                    for (int i = 0; i < ScanSession.Count; i++)
                    {
                        try
                        {
                            if (ScanSession[i].Unique == 2)
                            {
                                Status TempStatus = user.StatusesUser.First();

                                String Number = ScanSession[i].Order.Number;
                                String List = ScanSession[i].Order.List;

                                if (!SystemArgs.Request.InsertStatus(Number, List, TempStatus.ID, user))
                                {
                                    MessageBox.Show("Ошибка при добавлении в базу данных статуса для: Номер-" + ScanSession[i].Order.Number + "Лист-" + ScanSession[i].Order.List, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                SystemArgs.UnLoadSpecific.ChekedUnloading(Number, List, ScanSession[i].Order.Executor);
                            }
                        }
                        catch (Exception E)
                        {
                            ScanSession[i].Discription = E.Message;
                            ScanSession[i].Unique = 0;
                        }

                    }

                    if (SystemArgs.UnLoadSpecific.ExecutorMails.Count != 0)
                    {
                        KB_ScanUnloadSpecific unloadSpecific = new KB_ScanUnloadSpecific();
                        unloadSpecific.ShowDialog();
                    }

                    SystemArgs.UnLoadSpecific.ExecutorMails.Clear();

                    List<OrderScanSession> Temp = ScanSession.Where(p => p.Unique == 0 || p.Unique == 1).ToList();
                    if (Temp.Count() > 0)
                    {
                        KB_NotAdded_F Report = new KB_NotAdded_F();
                        Report.Report_DGV.AutoGenerateColumns = false;
                        Report.Report_DGV.DataSource = Temp;
                        Report.CountOrder_TB.Text = ScanSession.Count() - Temp.Count() + "/" + ScanSession.Count();
                        Report.ShowDialog();

                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception E)
            {
                SystemArgs.UnLoadSpecific.ExecutorMails.Clear();
                MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool ChangeOrder()
        {
            try
            {
                if (Order_DGV.CurrentCell != null && Order_DGV.CurrentCell.RowIndex >= 0 && Order_DGV.SelectedRows.Count == 1)
                {
                    Order Temp = (Order)View[Order_DGV.CurrentCell.RowIndex];

                    KB_ChangeOrder_F Dialog = new KB_ChangeOrder_F(Temp);

                    Dialog.Executor_TB.Text = Temp.Executor;
                    Dialog.Number_TB.Text = Temp.Number;
                    Dialog.List_TB.Text = Temp.List.ToString();
                    Dialog.Mark_TB.Text = Temp.Mark;
                    Dialog.Lenght_TB.Text = Temp.Lenght.ToString();
                    Dialog.Weight_TB.Text = Temp.Weight.ToString();

                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {
                        List<DateTime> StatusDate = SystemArgs.StatusOfOrders.Where(p => p.IDOrder == Temp.ID && p.IDStatus == Temp.Status.ID).Select(p => p.DateCreate).ToList();
                        Order NewOrder = new Order(Temp.ID, Temp.DateCreate, Dialog.Number_TB.Text, Dialog.Executor_TB.Text, Temp.ExecutorWork, Dialog.List_TB.Text, Dialog.Mark_TB.Text, Convert.ToDouble(Dialog.Lenght_TB.Text), Convert.ToDouble(Dialog.Weight_TB.Text), Temp.Status, StatusDate[0], Temp.TypeAdd, Temp.Model, Temp.User, Temp.BlankOrder, Temp.Canceled, Temp.Finished);

                        if (SystemArgs.Request.UpdateOrder(NewOrder))
                        {
                            SystemArgs.Orders.Remove(Temp);
                            SystemArgs.Orders.Add(NewOrder);

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
                    throw new Exception("Необходимо выбрать один объект");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool DeleteOrder()
        {
            try
            {
                if (Order_DGV.CurrentCell.RowIndex >= 0 && Order_DGV.SelectedRows.Count >= 0)
                {

                    if (MessageBox.Show("Вы действительно хотите удалить чертеж(ы)?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        for (int i = 0; i < Order_DGV.SelectedRows.Count; i++)
                        {
                            Order Temp = (Order)(View[Order_DGV.SelectedRows[i].Index]);

                            try
                            {
                                if (SystemArgs.Request.DeleteDetails(Temp.ID))
                                {
                                    if (SystemArgs.Request.DeleteOrder(Temp))
                                    {
                                        SystemArgs.Orders.Remove(Temp);
                                    }
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка удаления чертежа: Номер-" + Temp.Number + "Лист-" + Temp.List, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать объект(ы)");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Display(List<Order> List)
        {
            try
            {
                Order_DGV.Invoke((MethodInvoker)delegate ()
                {
                    int Index = -1;

                    Index = FilterCB_TSB.SelectedIndex;

                    if (Index >= 0)
                    {
                        View = null;
                        View = new SortableBindingList<Order>(List);

                        Order_DGV.DataSource = View;

                        if (View.Count > 0)
                        {
                            CountOrder_TB.Text = View.Count.ToString();
                            if (Index == 0)
                            {
                                VisibleButton(true);
                            }
                        }
                        else
                        {
                            CountOrder_TB.Text = "0";
                            SelectedOrder_TB.Text = "0";
                            if (Index == 0)
                            {
                                VisibleButton(false);
                            }
                        }

                        if (!UsedSearch)
                        {
                            if (Index == 0)
                            {
                                ForgetOrder();
                            }
                            else
                            {
                                VisibleButton(false);
                            }
                        }
                    }
                });
            }
            catch (Exception e)
            {
                SystemArgs.PrintLog(e.ToString());
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ForgetOrder()
        {
            for (int i = 0; i < Order_DGV.RowCount; i++)
            {
                if ((DateTime.Now - Convert.ToDateTime(Order_DGV["StatusDate", i].Value)).TotalDays >= SystemArgs.SettingsProgram.VisualRow_N2)
                {
                    Order_DGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(236, 0, 6);
                }
                else if ((DateTime.Now - Convert.ToDateTime(Order_DGV["StatusDate", i].Value)).TotalDays >= SystemArgs.SettingsProgram.VisualRow_N1)
                {
                    Order_DGV.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        private void Order_DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (Order_DGV.CurrentCell != null && Order_DGV.CurrentCell.RowIndex < View.Count())
            {
                Order Temp = (Order)View[Order_DGV.CurrentCell.RowIndex];
                Selection(Temp, true);
            }
            else
            {
                Selection(null, false);
            }
        }

        private void KB_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < SystemArgs.SelectedColumn.GetColumns().Count; i++)
            {
                if (Order_DGV.Columns[i].Visible)
                {
                    SystemArgs.SelectedColumn[i].DisplayIndex = Order_DGV.Columns[SystemArgs.SelectedColumn[i].Name].DisplayIndex;
                    SystemArgs.SelectedColumn[i].FillWeight = Order_DGV.Columns[SystemArgs.SelectedColumn[i].Name].FillWeight;
                }
            }
            SystemArgs.SelectedColumn.SetParametrColumnDisplayIndex();
            SystemArgs.SelectedColumn.SetParametrColumnFillWeight();
            Application.Exit();
        }

        private void Order_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(112, 238, 226);
            e.CellStyle.SelectionForeColor = Color.Black;
        }

        private void FilterCB_TSB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetSearch();
        }

        private void ItemsFilter()
        {
            FilterCB_TSB.Items.Add("Текущий статус");
            FilterCB_TSB.Items.Add("Все статусы");
            FilterCB_TSB.Items.Add("Аннулированные");
            FilterCB_TSB.Items.Add("Завершенные");
        }

        private List<Order> ResultSearch(String TextSearch)
        {
            List<Order> Result = new List<Order>();

            if (!String.IsNullOrEmpty(TextSearch))
            {
                foreach (Order Temp in SystemArgs.Orders)
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
                if (!String.IsNullOrEmpty(Search_TSTB.Text))
                {
                    String SearchText = Search_TSTB.Text.Trim();

                    SystemArgs.Orders = ResultSearch(SearchText);

                    if (SystemArgs.Orders.Count <= 0)
                    {
                        Search_TSTB.Focus();
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

        private void ResetSearch()
        {
            UsedSearch = false;

            if (SystemArgs.Orders != null)
            {
                SystemArgs.Orders.Clear();
            }
            Search_TSTB.Text = String.Empty;

            RefreshOrderAsync(FilterCB_TSB.SelectedIndex);
        }
        private void GetDataForSearch(ForLongOperations_F Load, bool Finished)
        {
            try
            {
                SystemArgs.Orders.Clear();
                SystemArgs.BlankOrders.Clear();
                SystemArgs.StatusOfOrders.Clear();
                SystemArgs.BlankOrderOfOrders.Clear();

                SystemArgs.RequestLinq.GetOrdersForSearch(Load, Finished);
            }
            catch (Exception Ex)
            {
                SystemArgs.PrintLog(Ex.ToString());
                throw new Exception(Ex.Message, Ex);
            }
        }
        private async void SearchParamAsync()
        {
            try
            {
                KB_SearchParam_F Dialog = new KB_SearchParam_F();

                List<Status> Statuses = new List<Status>
                {
                    new Status(-1, 0, "Не задан")
                };
                Statuses.AddRange(SystemArgs.Statuses);
                Dialog.Status_CB.DataSource = Statuses;

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    bool Finished = true;

                    if (Dialog.Finished_CB.Checked && Dialog.Number_TB.Text == String.Empty && Dialog.List_TB.Text == String.Empty)
                    {
                        if (MessageBox.Show("Вы уверены в выводе всех завершенных чертежей?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                        {
                            Finished = false;
                        }
                    }
                    else
                    {
                        if (!Dialog.Finished_CB.Checked)
                        {
                            Finished = false;
                        }
                    }

                    ForLongOperations_F Load = new ForLongOperations_F();
                    Load.Show();

                    LockedButtonForLoadData(false);

                    await Task.Run(() => GetDataForSearch(Load, Finished));

                    LockedButtonForLoadData(true);

                    Load.Close();

                    if (!Dialog.Cancelled_CB.Checked)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => !p.Canceled).ToList();
                    }

                    SystemArgs.Orders.ToList();

                    if (Dialog.DateEnable_CB.Checked && Dialog.Status_CB.SelectedIndex != 0)
                    {
                        Status Status = (Status)Dialog.Status_CB.SelectedItem;
                        var Orders = SystemArgs.StatusOfOrders.Where(p => p.DateCreate >= Dialog.First_DP.Value.Date && p.DateCreate <= Dialog.Second_DP.Value.Date.AddSeconds(86399) && p.IDStatus == Status.ID);
                        List<Order> Temp = new List<Order>();
                        foreach (var item in Orders)
                        {
                            List<Order> Order = SystemArgs.Orders.Where(p => p.ID == item.IDOrder).ToList();
                            if (Order.Count > 0)
                            {
                                Temp.Add(new Order(Order[0].ID, Order[0].DateCreate, Order[0].Number, Order[0].Executor, Order[0].ExecutorWork, Order[0].List, Order[0].Mark, Order[0].Lenght, Order[0].Weight, Order[0].Status, Order[0].StatusDate, Order[0].TypeAdd, Order[0].Model, Order[0].User, Order[0].BlankOrder, Order[0].Canceled, Order[0].Finished));
                            }
                        }
                        SystemArgs.Orders = Temp;
                    }
                    else if (Dialog.DateEnable_CB.Checked)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => (p.DateCreate >= Dialog.First_DP.Value.Date) && (p.DateCreate <= Dialog.Second_DP.Value.Date.AddSeconds(86399))).ToList();
                    }
                    else if (Dialog.Status_CB.SelectedIndex > 0)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.Status == (Status)Dialog.Status_CB.SelectedItem).ToList();
                    }

                    if (Dialog.Executor_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.Executor.IndexOf(Dialog.Executor_TB.Text.Trim()) != -1).ToList();
                    }

                    if (Dialog.ExecutorWork_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.ExecutorWork.IndexOf(Dialog.ExecutorWork_TB.Text.Trim()) != -1).ToList();
                    }

                    if (Dialog.Number_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.Number.IndexOf(Dialog.Number_TB.Text.Trim()) != -1).ToList();
                    }

                    if (Dialog.List_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.List.IndexOf(Dialog.List_TB.Text.Trim()) != -1).ToList();
                    }

                    if (Dialog.Mark_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.Mark.IndexOf(Dialog.Mark_TB.Text.Trim()) != -1).ToList();
                    }

                    if (Dialog.Lenght_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.Lenght.ToString().IndexOf(Dialog.Lenght_TB.Text.Trim()) != -1).ToList();
                    }

                    if (Dialog.Weight_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.Weight == Convert.ToDouble(Dialog.Weight_TB.Text.Trim())).ToList();
                    }

                    if (Dialog.NumberBlankOrder_TB.Text.Trim() != String.Empty)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.BlankOrderView.IndexOf(Dialog.NumberBlankOrder_TB.Text.Trim()) != -1).ToList();
                    }

                    if (Dialog.User_CB.SelectedIndex > 0)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.Where(p => p.User == (Models.User)Dialog.User_CB.SelectedItem).ToList();
                    }

                    UsedSearch = true;

                    Display(SystemArgs.Orders);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ReportOrderOfDate()
        {
            try
            {
                KB_ReportOrderOfDate_F Dialog = new KB_ReportOrderOfDate_F();
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    if (SystemArgs.Excel.ReportOrderOfDate(Dialog.First_MC.SelectionStart, Dialog.Second_MC.SelectionStart))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void VisibleButton(Boolean Enable)
        {
            if (Enable)
            {
                ChangeOrder_TSB.Visible = true;
                DeleteOrder_TSB.Visible = true;
                ChangeOrder_TSM.Visible = true;
                DeleteOrder_TSM.Visible = true;
                CanceledOrder_TSB.Visible = true;
                SelectionReport_TSM.Visible = true;
                ViewSelected_B.Visible = true;

            }
            else
            {
                ChangeOrder_TSB.Visible = false;
                DeleteOrder_TSB.Visible = false;
                ChangeOrder_TSM.Visible = false;
                DeleteOrder_TSM.Visible = false;
                CanceledOrder_TSB.Visible = false;
                SelectionReport_TSM.Visible = false;
                ViewSelected_B.Visible = false;
            }
        }
        private void Selection(Order Temp, bool flag)
        {
            if (flag)
            {
                DateCreate_TB.Text = Temp.DateCreate.ToString();
                Executor_TB.Text = Temp.Executor;
                ExecutorWork_TB.Text = Temp.ExecutorWork;
                Number_TB.Text = Temp.Number;
                List_TB.Text = Temp.List.ToString();
                Mark_TB.Text = Temp.Mark;
                Lenght_TB.Text = Temp.Lenght.ToString();
                Weight_TB.Text = Temp.Weight.ToString();
                if (Temp.Canceled)
                {
                    Canceled_TB.BackColor = Color.Orange;
                    Canceled_TB.Text = "Да";
                }
                else
                {
                    Canceled_TB.BackColor = Color.Lime;
                    Canceled_TB.Text = "Нет";
                }
                if (Temp.Finished)
                {
                    Finished_TB.BackColor = Color.Orange;
                    Finished_TB.Text = "Да";
                }
                else
                {
                    Finished_TB.BackColor = Color.Lime;
                    Finished_TB.Text = "Нет";
                }
                BlankOrder_TB.Text = Temp.BlankOrder.QR;
                Status_TB.Text = Temp.Status.Name;
                SelectedOrder_TB.Text = Order_DGV.SelectedRows.Count.ToString();

            }
            else
            {
                DateCreate_TB.Text = String.Empty;
                Executor_TB.Text = String.Empty;
                ExecutorWork_TB.Text = String.Empty;
                Number_TB.Text = String.Empty;
                List_TB.Text = String.Empty;
                Mark_TB.Text = String.Empty;
                Lenght_TB.Text = String.Empty;
                Weight_TB.Text = String.Empty;
                Canceled_TB.BackColor = Color.FromArgb(233, 245, 255);
                Canceled_TB.Text = String.Empty;
                Finished_TB.BackColor = Color.FromArgb(233, 245, 255);
                Finished_TB.Text = String.Empty;
                BlankOrder_TB.Text = String.Empty;
                Status_TB.Text = String.Empty;
                SelectedOrder_TB.Text = "0";
            }

        }

        private async void RefreshOrderAsync(int ForViews)
        {
            ForLongOperations_F Dialog = new ForLongOperations_F();
            Dialog.Show();

            LockedButtonForLoadData(false);

            await Task.Run(() => RefreshOrder(ForViews, Dialog));

            LockedButtonForLoadData(true);

            Dialog.Close();
        }

        private void LockedButtonForLoadData(bool flag)
        {
            AddOrder_TSB.Enabled = flag;
            AddOrder_TSM.Enabled = flag;
            ChangeOrder_TSB.Enabled = flag;
            ChangeOrder_TSM.Enabled = flag;
            DeleteOrder_TSB.Enabled = flag;
            DeleteOrder_TSM.Enabled = flag;
            Search_TSB.Enabled = flag;
            Reset_TSB.Enabled = flag;
            AdvancedSearch_TSB.Enabled = flag;
            FilterCB_TSB.Enabled = flag;
            RefreshStatus_B.Enabled = flag;
            CanceledOrder_TSB.Enabled = flag;
            ReportDate_TSM.Enabled = flag;
            SelectionReport_TSM.Enabled = flag;
            Time_Day_Report_TSM.Enabled = flag;
            Time_Week_Report_TSM.Enabled = flag;
            Time_Month_Report_TSM.Enabled = flag;
            Time_SelectionDate_Report_TSM.Enabled = flag;
            ViewSelected_B.Enabled = flag;
        }

        private void RefreshOrder(int ForViews, ForLongOperations_F Dialog)
        {
            try
            {
                SystemArgs.Orders.Clear();
                SystemArgs.BlankOrders.Clear();
                SystemArgs.StatusOfOrders.Clear();
                SystemArgs.BlankOrderOfOrders.Clear();

                GetOrders(ForViews, Dialog);

                Display(SystemArgs.Orders);
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());

                MessageBox.Show("Ошибка получения данных для обновления информации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Environment.Exit(0);
            }
        }
        private void GetOrders(int ForViews, ForLongOperations_F Dialog)
        {
            switch (ForViews)
            {
                case 0:
                    SystemArgs.RequestLinq.GetOrdersUser(Dialog);
                    break;
                case 1:
                    SystemArgs.RequestLinq.GetOrdersAll(Dialog);
                    break;
                case 2:
                    SystemArgs.RequestLinq.GetOrdersCancelled(Dialog);
                    break;
                case 3:
                    SystemArgs.RequestLinq.GetOrdersFinished(Dialog);
                    break;
            }
        }

        private void RefreshStatus_B_Click(object sender, EventArgs e)
        {
            try
            {
                ResetSearch();
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Order_DGV_Sorted(object sender, EventArgs e)
        {
            try
            {
                if (FilterCB_TSB.SelectedIndex == 0)
                {
                    ForgetOrder();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SettingMobile_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                Settings_MobileApp Dialog = new Settings_MobileApp();

                if (SystemArgs.MobileApplication.GetParametersConnect())
                {
                    String MyIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

                    Dialog.IP_TB.Text = MyIP;
                    Dialog.Port_TB.Text = SystemArgs.MobileApplication.Port;

                    Zen.Barcode.CodeQrBarcodeDraw QrCode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    Dialog.QR_PB.Image = QrCode.Draw($"{MyIP}_{SystemArgs.MobileApplication.Port}", 100);
                }

                if (Dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectionReport_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                List<Order> Report = new List<Order>();
                if (Order_DGV.CurrentCell != null && Order_DGV.CurrentCell.RowIndex >= 0)
                {
                    for (int i = 0; i < Order_DGV.SelectedRows.Count; i++)
                    {
                        Report.Add((Order)(View[Order_DGV.SelectedRows[i].Index]));
                    }
                    SystemArgs.Excel.ReportOrderOfSelect(Report);
                }
                else
                {
                    throw new Exception("Необходимо выбрать чертежи");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CanceledOrder_TSB_Click(object sender, EventArgs e)
        {
            try
            {
                if (Order_DGV.CurrentCell.RowIndex >= 0 && Order_DGV.SelectedRows.Count >= 0)
                {
                    if (MessageBox.Show("Изменить статус аннулирования чертежа(ей)?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        for (int i = 0; i < Order_DGV.SelectedRows.Count; i++)
                        {
                            Order Temp = (Order)(View[Order_DGV.SelectedRows[i].Index]);

                            try
                            {
                                Temp.Canceled = !Temp.Canceled;
                                SystemArgs.Request.CanceledOrder(Temp.Canceled, Temp.ID);
                                SystemArgs.Orders.Remove(Temp);
                            }
                            catch
                            {
                                MessageBox.Show("Произошла ошибка при аннулировании чертежа: Номер-" + Temp.Number + " Лист-" + Temp.List, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        Display(SystemArgs.Orders);
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать один объект(ы)");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Time_Day_Report_TSM_Click(object sender, EventArgs e)
        {
            ReportTimeofOrderPeriod(new TimeSpan(1, 0, 0, 1));
        }

        private void Time_Week_Report_TSM_Click(object sender, EventArgs e)
        {
            ReportTimeofOrderPeriod(new TimeSpan(7, 0, 0, 1));
        }

        private void Time_Month_Report_TSM_Click(object sender, EventArgs e)
        {
            ReportTimeofOrderPeriod(new TimeSpan(30, 0, 0, 1));
        }

        private void Time_SelectionDate_Report_TSM_Click(object sender, EventArgs e)
        {
            ReportTimeofOrder();
        }

        private void ReportTimeofOrderPeriod(object aInterval)
        {
            try
            {
                SaveFileDialog SaveReport = new SaveFileDialog();
                String date = DateTime.Now.ToString();
                date = date.Replace(".", "_");
                date = date.Replace(":", "_");
                SaveReport.FileName = "Отчет по времени за выбранный период от " + date;
                SaveReport.Filter = "Excel Files .xlsx|*.xlsx";
                if (SaveReport.ShowDialog() == DialogResult.OK)
                {
                    ALL_FormingReportForAllPosition_F FormingF = new ALL_FormingReportForAllPosition_F();
                    FormingF.Show();
                    List<StatusOfOrder> Report = SystemArgs.StatusOfOrders.Where(p => p.DateCreate <= DateTime.Now && p.DateCreate >= DateTime.Now.Subtract((TimeSpan)aInterval)).ToList();
                    Task<Boolean> task = ReportPastTimeAsync(Report, SaveReport.FileName);
                    task.ContinueWith(t =>
                    {
                        if (t.Result)
                        {
                            FormingF.Invoke((MethodInvoker)delegate ()
                            {
                                FormingF.Close();
                            });
                            if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                if (File.Exists(SaveReport.FileName))
                                {
                                    Process.Start(SaveReport.FileName);
                                }
                                else
                                {
                                    MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            FormingF.Invoke((MethodInvoker)delegate ()
                            {
                                FormingF.Close();
                            });
                            MessageBox.Show("Ошибка фомирования отчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReportTimeofOrder()
        {
            try
            {
                KB_ReportOrderOfDate_F Dialog = new KB_ReportOrderOfDate_F();
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFileDialog SaveReport = new SaveFileDialog();
                    String date = DateTime.Now.ToString();
                    date = date.Replace(".", "_");
                    date = date.Replace(":", "_");
                    SaveReport.FileName = "Отчет по времени за выбранный период от " + date;
                    SaveReport.Filter = "Excel Files .xlsx|*.xlsx";
                    if (SaveReport.ShowDialog() == DialogResult.OK)
                    {
                        ALL_FormingReportForAllPosition_F FormingF = new ALL_FormingReportForAllPosition_F();
                        FormingF.Show();
                        List<StatusOfOrder> Report = SystemArgs.StatusOfOrders.Where(p => p.DateCreate >= Dialog.First_MC.SelectionStart && p.DateCreate <= Dialog.Second_MC.SelectionStart).ToList();
                        Task<Boolean> task = ReportPastTimeAsync(Report, SaveReport.FileName);
                        task.ContinueWith(t =>
                        {
                            if (t.Result)
                            {
                                FormingF.Invoke((MethodInvoker)delegate ()
                                {
                                    FormingF.Close();
                                });
                                if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    if (File.Exists(SaveReport.FileName))
                                    {
                                        Process.Start(SaveReport.FileName);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                FormingF.Invoke((MethodInvoker)delegate ()
                                {
                                    FormingF.Close();
                                });
                                MessageBox.Show("Ошибка фомирования отчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        });
                    }
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<Boolean> ReportPastTimeAsync(List<StatusOfOrder> Report, String filename)
        {
            return await Task.Run(() => SystemArgs.Excel.ReportPastTimeofDate(Report, filename));
        }

        private void AboutProgram_TSM_Click(object sender, EventArgs e)
        {
            ALL_AboutProgram_F Dialog = new ALL_AboutProgram_F();
            if (Dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
        public static void SetDoubleBuffered(Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        private void SelectedColumnDGV()
        {
            try
            {
                List<Column> Temp = SystemArgs.SelectedColumn.GetColumns().OrderBy(p => p.DisplayIndex).ToList();
                for (int i = 0; i < Temp.Count(); i++)
                {
                    Order_DGV.Columns[Temp[i].Name].DisplayIndex = Temp[i].DisplayIndex;
                    Order_DGV.Columns[Temp[i].Name].Visible = Temp[i].Visible;
                    Order_DGV.Columns[Temp[i].Name].FillWeight = Temp[i].FillWeight;
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                throw new Exception(E.Message);
            }
        }

        private void SelectedColumn_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                KB_SelectedColumnDGV_F Dialog = new KB_SelectedColumnDGV_F();

                Dialog.DataMatrix_CB.Checked = SystemArgs.SelectedColumn[0].Visible;
                Dialog.DateCreate_CB.Checked = SystemArgs.SelectedColumn[1].Visible;
                Dialog.Number_CB.Checked = SystemArgs.SelectedColumn[2].Visible;
                Dialog.Executor_CB.Checked = SystemArgs.SelectedColumn[3].Visible;
                Dialog.ExecutorWork_CB.Checked = SystemArgs.SelectedColumn[4].Visible;
                Dialog.List_CB.Checked = SystemArgs.SelectedColumn[5].Visible;
                Dialog.Mark_CB.Checked = SystemArgs.SelectedColumn[6].Visible;
                Dialog.Lenght_CB.Checked = SystemArgs.SelectedColumn[7].Visible;
                Dialog.Height_CB.Checked = SystemArgs.SelectedColumn[8].Visible;
                Dialog.Status_CB.Checked = SystemArgs.SelectedColumn[9].Visible;
                Dialog.User_CB.Checked = SystemArgs.SelectedColumn[10].Visible;
                Dialog.BlankOrder_CB.Checked = SystemArgs.SelectedColumn[11].Visible;
                Dialog.Cancelled_CB.Checked = SystemArgs.SelectedColumn[12].Visible;
                Dialog.StatusDate_CB.Checked = SystemArgs.SelectedColumn[13].Visible;
                Dialog.Finished_CB.Checked = SystemArgs.SelectedColumn[14].Visible;

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    SystemArgs.SelectedColumn[0].Visible = Dialog.DataMatrix_CB.Checked;
                    SystemArgs.SelectedColumn[1].Visible = Dialog.DateCreate_CB.Checked;
                    SystemArgs.SelectedColumn[2].Visible = Dialog.Number_CB.Checked;
                    SystemArgs.SelectedColumn[3].Visible = Dialog.Executor_CB.Checked;
                    SystemArgs.SelectedColumn[4].Visible = Dialog.ExecutorWork_CB.Checked;
                    SystemArgs.SelectedColumn[5].Visible = Dialog.List_CB.Checked;
                    SystemArgs.SelectedColumn[6].Visible = Dialog.Mark_CB.Checked;
                    SystemArgs.SelectedColumn[7].Visible = Dialog.Lenght_CB.Checked;
                    SystemArgs.SelectedColumn[8].Visible = Dialog.Height_CB.Checked;
                    SystemArgs.SelectedColumn[9].Visible = Dialog.Status_CB.Checked;
                    SystemArgs.SelectedColumn[10].Visible = Dialog.User_CB.Checked;
                    SystemArgs.SelectedColumn[11].Visible = Dialog.BlankOrder_CB.Checked;
                    SystemArgs.SelectedColumn[12].Visible = Dialog.Cancelled_CB.Checked;
                    SystemArgs.SelectedColumn[13].Visible = Dialog.StatusDate_CB.Checked;
                    SystemArgs.SelectedColumn[14].Visible = Dialog.Finished_CB.Checked;
                    SystemArgs.SelectedColumn.SetParametrColumnVisible();
                    MessageBox.Show("Настройки успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SelectedColumnDGV();
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SettingWebcam_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                KB_SettingWebcam_F Dialog = new KB_SettingWebcam_F();
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count > 0)
                {
                    foreach (FilterInfo device in videoDevices)
                    {
                        Dialog.WB_LB.Items.Add(device.Name);
                    }
                    Dialog.WB_LB.SelectedIndex = 0;
                }
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    XDocument doc = XDocument.Load(SystemArgs.Path.UserWebCamDevice);
                    doc.Element("Device").SetValue(videoDevices[Dialog.WB_LB.SelectedIndex].MonikerString);
                    doc.Save(SystemArgs.Path.UserWebCamDevice);
                    MessageBox.Show("Настройки успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SettingConfig_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                KB_SettingConfig_F Dialog = new KB_SettingConfig_F();

                if (SystemArgs.SettingsUser.GetParametersConnect())
                {
                    string[] Types = new string[] { "Сканер", "Вебкамера", "Мобильное приложение" };

                    Dialog.TypesScan_CB.Items.AddRange(Types);
                    Dialog.TypesScan_CB.SelectedIndex = SystemArgs.SettingsUser.TypeScan;
                }

                if (Dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Order_DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (Order_DGV.CurrentCell != null && Order_DGV.CurrentCell.RowIndex < View.Count() && e.RowIndex >= 0)
                {
                    Order Temp = (Order)View[Order_DGV.CurrentCell.RowIndex];
                    KB_DetailedInformationOrder_F Dialog = new KB_DetailedInformationOrder_F();
                    List<StatusOfOrder> Statuses = SystemArgs.StatusOfOrders.Where(p => p.IDOrder == Temp.ID).OrderBy(p => p.DateCreate).ToList();
                    for (int i = 0; i < Statuses.Count; i++)
                    {
                        Dialog.Statuses_DGV.Rows.Add();
                        Dialog.Statuses_DGV[0, i].Value = SystemArgs.Statuses.Where(p => p.ID == Statuses[i].IDStatus).Select(p => p.Name).Single();
                        Dialog.Statuses_DGV[1, i].Value = Statuses[i].DateCreate;
                        Models.User TempUser = SystemArgs.Users.Where(p => p.ID == Statuses[i].IDUser).Single();
                        Dialog.Statuses_DGV[2, i].Value = TempUser.Surname + " " + TempUser.Name.First() + "." + TempUser.MiddleName.First() + ".";
                    }
                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Steel_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                if (Order_DGV.CurrentCell != null && Order_DGV.CurrentCell.RowIndex >= 0)
                {
                    SaveFileDialog SaveReport = new SaveFileDialog();
                    String date = DateTime.Now.ToString();
                    date = date.Replace(".", "_");
                    date = date.Replace(":", "_");
                    SaveReport.FileName = "Отчет выборки металла от " + date;
                    SaveReport.Filter = "Excel Files .xlsx|*.xlsx";
                    List<Order> Report = new List<Order>();

                    for (int i = 0; i < Order_DGV.SelectedRows.Count; i++)
                    {
                        Report.Add((Order)(View[Order_DGV.SelectedRows[i].Index]));
                    }

                    if (SaveReport.ShowDialog() == DialogResult.OK)
                    {

                        ALL_FormingReportForAllPosition_F FormingF = new ALL_FormingReportForAllPosition_F();
                        FormingF.Show();
                        Task<Boolean> task = ReportSteelAsync(Report, SaveReport.FileName);
                        task.ContinueWith(t =>
                        {
                            if (t.Result)
                            {
                                FormingF.Invoke((MethodInvoker)delegate ()
                                {
                                    FormingF.Close();
                                });
                                if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    if (File.Exists(SaveReport.FileName))
                                    {
                                        Process.Start(SaveReport.FileName);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                FormingF.Invoke((MethodInvoker)delegate ()
                                {
                                    FormingF.Close();
                                });
                                MessageBox.Show("Ошибка фомирования отчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        });
                    }
                }
                else
                {
                    throw new Exception("Необходимо выбрать чертежи");
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<Boolean> ReportSteelAsync(List<Order> Report, String filename)
        {
            return await Task.Run(() => SystemArgs.Excel.ReportSteelOfDate(Report, filename));
        }

        private void SettingScanner_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                KB_SettingScannerPort_F Dialog = new KB_SettingScannerPort_F();
                string[] ports = SerialPort.GetPortNames();
                if (ports.Length > 0)
                {
                    foreach (string port in ports)
                    {
                        Dialog.WB_LB.Items.Add(port);
                    }
                    Dialog.WB_LB.SelectedIndex = 0;
                }
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    XDocument doc = XDocument.Load(SystemArgs.Path.UserScannerPort);
                    doc.Element("Port").SetValue(Dialog.WB_LB.SelectedItem.ToString());
                    doc.Save(SystemArgs.Path.UserScannerPort);
                    MessageBox.Show("Настройки успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XML_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Opd = new OpenFileDialog
                {
                    Title = "Выберите отчёт для добавления",
                    Filter = "XML|*.xml"
                };

                if (Opd.ShowDialog() == DialogResult.OK)
                {
                    FolderBrowserDialog Fbd = new FolderBrowserDialog()
                    {
                        ShowNewFolderButton = false,
                        Description = "Выберите папку с моделью",
                        SelectedPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Opd.FileName))
                    };

                    if (Fbd.ShowDialog() == DialogResult.OK)
                    {
                        StartingParseAsync(Opd.FileName, Fbd.SelectedPath);
                    }
                }
            }
            catch (Exception Ex)
            {
                SystemArgs.PrintLog(Ex.ToString());
                MessageBox.Show(Ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void StartingParseAsync(string FileName, string ModelPath)
        {
            try
            {
                ForLongOperations_F Notify = new ForLongOperations_F();
                Notify.Show();

                ParseXML parseXML = new ParseXML();
                await Task.Run(() => parseXML.Start(FileName, ModelPath, Notify));

                Notify.Hide();

                if (parseXML.ErrorOrders.Count != 0)
                {
                    ReportErrors report = new ReportErrors();
                    report.Report_DGV.AutoGenerateColumns = false;
                    report.Report_DGV.DataSource = parseXML.ErrorOrders;

                    report.ShowDialog();
                }

                if (parseXML.Orders.Count > 0)
                {
                    KB_AddXML Dialog = new KB_AddXML();

                    Dialog.Data_TV.Nodes.AddRange(parseXML.TreeNodes.ToArray());
                    Dialog.Count_TB.Text = parseXML.Orders.Count.ToString();

                    if (Dialog.ShowDialog() == DialogResult.OK)
                    {
                        Notify.Show();

                        await Task.Run(() => parseXML.CheckedData());

                        await Task.Run(() => AddXMLData(parseXML.OrderScanSession, Notify));

                        RefreshOrderAsync(FilterCB_TSB.SelectedIndex);
                    }
                }
            }
            catch (Exception Ex)
            {
                SystemArgs.PrintLog(Ex.ToString());
                MessageBox.Show(Ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddXMLData(List<OrderScanSession> Session, INotifyProcess notify)
        {
            try
            {
                Int64 IndexOrder = -1;

                notify.SetMaximum(Session.Count);

                for (int i = 0; i < Session.Count; i++)
                {
                    notify.Notify(i, $"Добавление {i + 1} чертежа из {Session.Count}");

                    try
                    {
                        if (Session[i].Unique == 1)
                        {
                            IndexOrder = SystemArgs.Request.GetLastIDOrder();

                            String[] ListCanceled = Session[i].Order.List.Split('и');

                            if (ListCanceled.Length != 1)
                            {
                                List<Int64> CanceledDrawings = SystemArgs.Request.GetIDOrdersForCancelled(ListCanceled[0], Session[i].Order.Number);

                                if (CanceledDrawings.Count() > 0)
                                {
                                    for (Int32 j = 0; j < CanceledDrawings.Count; j++)
                                    {
                                        SystemArgs.Request.CanceledOrder(true, CanceledDrawings[j]);
                                    }
                                }
                            }

                            Status TempStatus = SystemArgs.Statuses.FindAll(p => p.ID == SystemArgs.User.StatusesUser.First().ID - 1).First();

                            Session[i].Order.ID = SystemArgs.Request.GetLastIDOrder() + 1;
                            Session[i].Order.Status = TempStatus;
                            Session[i].Order.TypeAdd = SystemArgs.TypesAdds.FindAll(p => p.Discriprion == "XML").FirstOrDefault();

                            if (!SystemArgs.Request.ModelExist(Session[i].Order.Model))
                            {
                                SystemArgs.Request.InsertModel(Session[i].Order.Model);
                            }

                            Session[i].Order.Model = SystemArgs.Request.GetModel(Session[i].Order.Model);

                            if (SystemArgs.Request.InsertOrder(Session[i].Order))
                            {
                                if (!(SystemArgs.Request.SetModelOrder(Session[i].Order) && SystemArgs.Request.SetTypeAddOrder(Session[i].Order)))
                                {
                                    MessageBox.Show("Ошибка при добавлении данных о модели и типа добавления в базу данных DataMatrix: Номер-" + Session[i].Order.Number + " Лист-" + Session[i].Order.List, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                for (int k = 0; k < Session[i].Order.CountMarks; k++)
                                {
                                    for (int j = 0; j < Session[i].Order.Details.Count; j++)
                                    {
                                        Session[i].Order.Details[j].ID = SystemArgs.Request.GetAutoIDDetail() + 1;

                                        SystemArgs.Request.InsertDetail(Session[i].Order.Details[j]);
                                        SystemArgs.Request.InsertAddDetail(Session[i].Order, Session[i].Order.Details[j]);
                                    }
                                }

                                if (!SystemArgs.Request.StatusExist(Session[i].Order.ID, TempStatus.ID))
                                {
                                    SystemArgs.Request.InsertStatus(Session[i].Order.Number, Session[i].Order.List, TempStatus.ID, SystemArgs.User);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при добавлении в базу данных DataMatrix: Номер-" + Session[i].Order.Number + " Лист-" + Session[i].Order.List, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (Session[i].Unique == 2)
                        {
                            Session[i].Discription = $"В заказе {Session[i].Order.Number}, номер листа {Session[i].Order.List} уже существует.";
                        }
                        else if (Session[i].Unique == 3)
                        {
                            Session[i].Order.ExecutorWork = "Исполнитель не определен";
                            Session[i].Order.Canceled = false;
                            Session[i].Order.Finished = false;
                            Session[i].Order.ID = SystemArgs.Request.GetIDOrder(Session[i].Order.Number, Session[i].Order.List);
                            Session[i].Order.Status = SystemArgs.Statuses.Where(p=>p.ID==1).First();
                            Session[i].Order.User = SystemArgs.User;
                            if (!SystemArgs.Request.UpdateOrder(Session[i].Order)| !SystemArgs.Request.DownGradeStatus(Session[i].Order))
                            {
                                throw new Exception("Ошибка обновления чертежа");
                            }
                        }
                    }
                    catch (Exception E)
                    {
                        Session[i].Discription = E.Message;
                        Session[i].Unique = 0;
                    }

                }

                List<OrderScanSession> Temp = Session.Where(p => p.Unique == 0 || p.Unique == 2).ToList();

                notify.CloseAsync();

                if (Temp.Count() > 0)
                {
                    KB_NotAdded_F Report = new KB_NotAdded_F();
                    Report.Report_DGV.AutoGenerateColumns = false;
                    Report.Report_DGV.DataSource = Temp;
                    Report.CountOrder_TB.Text = Session.Count() - Temp.Count() + "/" + Session.Count();
                    Report.ShowDialog();

                }

                if (Session.Count > Temp.Count)
                {
                    MessageBox.Show("Добавление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Session.Clear();
            }
            catch (Exception Ex)
            {
                notify.CloseAsync();

                Session.Clear();
                throw new Exception(Ex.Message, Ex);
            }
        }

        private void CompleteStatusReport_TSM_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog SaveReport = new SaveFileDialog();
                String date = DateTime.Now.ToString();
                date = date.Replace(".", "_");
                date = date.Replace(":", "_");
                SaveReport.FileName = "Отчет прохождения статусов от " + date;
                SaveReport.Filter = "Excel Files .xlsx|*.xlsx";

                if (SaveReport.ShowDialog() == DialogResult.OK)
                {

                    ALL_FormingReportForAllPosition_F FormingF = new ALL_FormingReportForAllPosition_F();
                    FormingF.Show();
                    Task<Boolean> task = ReportCompleteStatuses(SaveReport.FileName);
                    task.ContinueWith(t =>
                    {
                        if (t.Result)
                        {
                            FormingF.Invoke((MethodInvoker)delegate ()
                            {
                                FormingF.Close();
                            });
                            if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                if (File.Exists(SaveReport.FileName))
                                {
                                    Process.Start(SaveReport.FileName);
                                }
                                else
                                {
                                    MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            FormingF.Invoke((MethodInvoker)delegate ()
                            {
                                FormingF.Close();
                            });
                            MessageBox.Show("Ошибка фомирования отчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<Boolean> ReportCompleteStatuses(String filename)
        {
            return await Task.Run(() => SystemArgs.Excel.ReportCompleteStatuses(filename));
        }

        private void ViewSelected_B_Click(object sender, EventArgs e)
        {
            try
            {
                SystemArgs.Orders = new OperationsDisplayDrawings().ViewSeletedDrawing(ref Order_DGV);

                Display(SystemArgs.Orders);
            }
            catch (Exception ex)
            {
                SystemArgs.PrintLog(ex.ToString());
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Order_DGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (Order_DGV.Columns[e.ColumnIndex] == Order_DGV.Columns["List"])
                {
                    ListFieldSort listFieldSort = new ListFieldSort();

                    if (listFieldSort.IsSort)
                    {
                        Display(listFieldSort.SortAsc(View).ToList());
                    }
                    else
                    {
                        Display(listFieldSort.SortDesc(View).ToList());
                    }

                    listFieldSort.IsSort = !listFieldSort.IsSort;
                }
            }
            catch (Exception ex)
            {
                SystemArgs.PrintLog(ex.ToString());
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
