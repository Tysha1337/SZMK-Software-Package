using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.BindingModels;
using SZMK.Desktop.Models;
using SZMK.Desktop.Views.Shared.Interfaces;

namespace SZMK.Desktop.Services
{
    public class RequestLinq
    {
        public bool CompareBlankOrder(List<long> IDSOrders, String QR)
        {
            try
            {
                String[] Temp = QR.Split('_');
                if (SystemArgs.Request.GetIDBlankOrder(QR) != -1)
                {
                    if (SystemArgs.Request.InsertBlankOrderOfOrders(IDSOrders, QR))
                    {
                        return true;
                    }
                }
                else
                {
                    if (SystemArgs.Request.InsertBlankOrder(QR))
                    {
                        SystemArgs.BlankOrders.Clear();
                        SystemArgs.Request.GetAllBlankOrder();
                        if (SystemArgs.Request.GetIDBlankOrder(QR) != -1)
                        {
                            if (SystemArgs.Request.InsertBlankOrderOfOrders(IDSOrders, QR))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public Int64 GetOldIDBlankOrder(List<Order> Orders)
        {
            try
            {
                foreach (Order order in Orders)
                {
                    var Temp = SystemArgs.BlankOrderOfOrders.Where(p => p.IDOrder == order.ID).OrderBy(p => p.DateCreate).ToList();
                    if (Temp.Count() != 0)
                    {
                        return Temp.Last().IDBlankOrder;
                    }
                }

                return -1;
            }
            catch
            {
                return -1;
            }
        }
        public void GetOrdersUser(INotifyProcess notifier)
        {
            try
            {
                notifier.Notify(0,"Получение данных");

                if (GetData())
                {
                    notifier.Notify(15, "Группировка статусов");
                    var GroupStatuses = FormingGroupStatuses();

                    notifier.Notify(20, "Группировка бланков заказов");
                    var GroupBlankOrders = FormingGroupBlankOrders();

                    notifier.Notify(30, "Выборка статусов пользователя");
                    GroupStatuses = CurretStatusOfUser(GroupStatuses);

                    notifier.Notify(45, "Выборка необходимых чертежей");
                    List<OrdersGetting> Orders = GettingNeedOrders(GroupBlankOrders, GroupStatuses);

                    notifier.Notify(60, "Отбор полученных данных");
                    List<Order> Temp = new List<Order>();
                    SystemArgs.Orders = SystemArgs.Orders.FindAll(p => !p.Canceled && !p.Finished);

                    notifier.Notify(75, "Сопоставление данных");
                    for (int i = 0; i < Orders.Count(); i++)
                    {
                        var Order = SystemArgs.Orders.FindAll(p => p.ID == Orders[i].ID).SingleOrDefault();
                        if (Order != null)
                        {
                            Order.Status = Orders[i].Status;
                            Order.User = Orders[i].User;
                            Order.BlankOrder = Orders[i].BlankOrder;
                            Order.StatusDate = Orders[i].DateStatus;

                            Temp.Add(Order);
                        }
                    }

                    notifier.Notify(100, "Присвоение данных");
                    SystemArgs.Orders = Temp;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void GetOrdersAll(INotifyProcess notifier)
        {
            try
            {
                notifier.Notify(0, "Получение данных");
                if (GetData())
                {
                    notifier.Notify(15, "Группировка статусов");
                    var GroupStatuses = FormingGroupStatuses();

                    notifier.Notify(20, "Группировка бланков заказов");
                    var GroupBlankOrders = FormingGroupBlankOrders();

                    notifier.Notify(35, "Выборка необходимых чертежей");
                    List<OrdersGetting> Orders = GettingNeedOrders(GroupBlankOrders, GroupStatuses);

                    notifier.Notify(45, "Отбор полученных данных");
                    List<Order> Temp = new List<Order>();

                    SystemArgs.Orders = SystemArgs.Orders.FindAll(p => !p.Canceled && !p.Finished);

                    notifier.Notify(75, "Сопоставление данных");
                    for (int i = 0; i < SystemArgs.Orders.Count(); i++)
                    {
                        var Data = Orders.FindAll(p => p.ID == SystemArgs.Orders[i].ID).SingleOrDefault();
                        if (Data != null)
                        {
                            SystemArgs.Orders[i].Status = Data.Status;
                            SystemArgs.Orders[i].User = Data.User;
                            SystemArgs.Orders[i].BlankOrder = Data.BlankOrder;
                            SystemArgs.Orders[i].StatusDate = Data.DateStatus;

                            Temp.Add(SystemArgs.Orders[i]);
                        }
                    }

                    notifier.Notify(100, "Присвоение данных");
                    SystemArgs.Orders = Temp;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void GetOrdersCancelled(INotifyProcess notifier)
        {
            try
            {
                notifier.Notify(0, "Получение данных");
                if (GetData())
                {
                    notifier.Notify(15, "Группировка статусов");
                    var GroupStatuses = FormingGroupStatuses();

                    notifier.Notify(20, "Группировка бланков заказов");
                    var GroupBlankOrders = FormingGroupBlankOrders();

                    notifier.Notify(35, "Выборка необходимых чертежей");
                    List<OrdersGetting> Orders = GettingNeedOrders(GroupBlankOrders, GroupStatuses);

                    notifier.Notify(45, "Отбор полученных данных");
                    List<Order> Temp = new List<Order>();

                    SystemArgs.Orders = SystemArgs.Orders.FindAll(p => p.Canceled);

                    notifier.Notify(75, "Сопоставление данных");
                    for (int i = 0; i < SystemArgs.Orders.Count(); i++)
                    {
                        var Data = Orders.FindAll(p => p.ID == SystemArgs.Orders[i].ID).SingleOrDefault();
                        if (Data != null)
                        {
                            SystemArgs.Orders[i].Status = Data.Status;
                            SystemArgs.Orders[i].User = Data.User;
                            SystemArgs.Orders[i].BlankOrder = Data.BlankOrder;
                            SystemArgs.Orders[i].StatusDate = Data.DateStatus;

                            Temp.Add(SystemArgs.Orders[i]);
                        }
                    }

                    notifier.Notify(100, "Присвоение данных");
                    SystemArgs.Orders = Temp;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void GetOrdersFinished(INotifyProcess notifier)
        {
            try
            {
                notifier.Notify(0, "Получение данных");
                if (GetData())
                {
                    notifier.Notify(15, "Группировка статусов");
                    var GroupStatuses = FormingGroupStatuses();

                    notifier.Notify(20, "Группировка бланков заказов");
                    var GroupBlankOrders = FormingGroupBlankOrders();

                    notifier.Notify(35, "Выборка необходимых чертежей");
                    List<OrdersGetting> Orders = GettingNeedOrders(GroupBlankOrders, GroupStatuses);

                    notifier.Notify(45, "Отбор полученных данных");
                    List<Order> Temp = new List<Order>();

                    SystemArgs.Orders = SystemArgs.Orders.FindAll(p => p.Finished);

                    notifier.Notify(75, "Сопоставление данных");
                    for (int i = 0; i < SystemArgs.Orders.Count(); i++)
                    {
                        var Data = Orders.FindAll(p => p.ID == SystemArgs.Orders[i].ID).SingleOrDefault();
                        if (Data != null)
                        {
                            SystemArgs.Orders[i].Status = Data.Status;
                            SystemArgs.Orders[i].User = Data.User;
                            SystemArgs.Orders[i].BlankOrder = Data.BlankOrder;
                            SystemArgs.Orders[i].StatusDate = Data.DateStatus;

                            Temp.Add(SystemArgs.Orders[i]);
                        }
                    }

                    notifier.Notify(100, "Присвоение данных");
                    SystemArgs.Orders = Temp;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void GetOrdersForSearch(INotifyProcess notifier, bool Finished)
        {
            try
            {
                notifier.Notify(0, "Получение данных");
                if (GetData())
                {
                    notifier.Notify(15, "Группировка статусов");
                    var GroupStatuses = FormingGroupStatuses();

                    notifier.Notify(20, "Группировка бланков заказов");
                    var GroupBlankOrders = FormingGroupBlankOrders();

                    notifier.Notify(35, "Выборка необходимых чертежей");
                    List<OrdersGetting> Orders = GettingNeedOrders(GroupBlankOrders, GroupStatuses);

                    notifier.Notify(45, "Отбор полученных данных");
                    List<Order> Temp = new List<Order>();

                    if (!Finished)
                    {
                        SystemArgs.Orders = SystemArgs.Orders.FindAll(p=>!p.Finished);
                    }

                    notifier.Notify(75, "Сопоставление данных");
                    for (int i = 0; i < SystemArgs.Orders.Count(); i++)
                    {
                        var Data = Orders.FindAll(p => p.ID == SystemArgs.Orders[i].ID).SingleOrDefault();
                        if (Data != null)
                        {
                            SystemArgs.Orders[i].Status = Data.Status;
                            SystemArgs.Orders[i].User = Data.User;
                            SystemArgs.Orders[i].BlankOrder = Data.BlankOrder;
                            SystemArgs.Orders[i].StatusDate = Data.DateStatus;

                            Temp.Add(SystemArgs.Orders[i]);
                        }
                    }

                    notifier.Notify(100, "Присвоение данных");
                    SystemArgs.Orders = Temp;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private bool GetData()
        {
            try
            {
                SystemArgs.Request.GetAllBlankOrder();
                SystemArgs.Request.GetAllStatusOfUser();
                SystemArgs.Request.GetAllBlankOrderofOrders();
                SystemArgs.Request.GetAllOrders();

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private List<IGrouping<long, StatusOfOrder>> FormingGroupStatuses()
        {
            try
            {
                var GroupStatusesOrders = SystemArgs.StatusOfOrders.GroupBy(p => p.IDOrder).ToList();

                return GroupStatusesOrders;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private List<IGrouping<long, BlankOrderOfOrder>> FormingGroupBlankOrders()
        {
            try
            {
                var GroutBlanksOrders = SystemArgs.BlankOrderOfOrders.GroupBy(p => p.IDOrder).ToList();

                return GroutBlanksOrders;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private List<OrdersGetting> GettingNeedOrders(List<IGrouping<long, BlankOrderOfOrder>> BlankOrders, List<IGrouping<long, StatusOfOrder>> Statuses)
        {
            try
            {
                List<OrdersGetting> ordersGettings = new List<OrdersGetting>();

                foreach (var item in Statuses)
                {
                    var TempStatus = item.OrderBy(p => p.DateCreate).Last();

                    var FindBlank = BlankOrders.FindAll(p => p.Key == item.Key).FirstOrDefault();

                    BlankOrder blankOrder = new BlankOrder();

                    if (FindBlank != null)
                    {
                        Int64 IDBlankOrders = FindBlank.OrderBy(p => p.DateCreate).Last().IDBlankOrder;

                        if (IDBlankOrders != 0)
                        {
                            blankOrder = SystemArgs.BlankOrders.Find(p => p.ID == IDBlankOrders);
                        }
                    }
                    ordersGettings.Add(new OrdersGetting { ID = item.Key, Status = SystemArgs.Statuses.Find(p => p.ID == TempStatus.IDStatus), DateStatus = TempStatus.DateCreate, User = SystemArgs.Users.Find(p => p.ID == TempStatus.IDUser), BlankOrder = blankOrder });
                }

                return ordersGettings;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private List<IGrouping<long, StatusOfOrder>> CurretStatusOfUser(List<IGrouping<long, StatusOfOrder>> Statuses)
        {
            try
            {
                List<IGrouping<long, StatusOfOrder>> FiltringStatuses = new List<IGrouping<long, StatusOfOrder>>();

                for (int i = 0; i < SystemArgs.User.StatusesUser.Count(); i++)
                {
                    FiltringStatuses.AddRange(Statuses.FindAll(p => p.OrderBy(d => d.DateCreate).Last().IDStatus == SystemArgs.User.StatusesUser[i].ID));
                }
                return FiltringStatuses;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
