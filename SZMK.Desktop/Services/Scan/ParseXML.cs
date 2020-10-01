using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.Desktop.BindingModels;
using SZMK.Desktop.Models;
using SZMK.Desktop.Views.Shared;
using SZMK.Desktop.Views.Shared.Interfaces;

namespace SZMK.Desktop.Services.Scan
{
    public class ParseXML : BaseScanOrder
    {
        private INotifyProcess notify;
        public List<Order> Orders { get; set; }
        public List<TreeNode> TreeNodes { get; set; }
        public List<OrderScanSession> OrderScanSession { get; set; }
        public void Start(string FileName, string ModelPath, INotifyProcess notify)
        {
            try
            {
                this.notify = notify;

                notify.SetMaximum(1);
                notify.Notify(0, "Начато создание объектов");

                Orders = new List<Order>();
                TreeNodes = new List<TreeNode>();

                notify.Notify(0, "Создание объектов успешно завершено");

                Model Model = GetModel(ModelPath);
                List<Order> IterOrders = GetOrders(FileName, Model);
                Orders.AddRange(IterOrders);
                TreeNodes.Add(GetTreeNodeModel(Model, IterOrders));
            }
            catch (Exception Ex)
            {
                notify.CloseAsync();

                Orders.Clear();
                TreeNodes.Clear();

                throw new Exception(Ex.Message, Ex);
            }
        }
        private Model GetModel(string path)
        {
            try
            {
                return new Model { ID = 0, DateCreate = DateTime.Now, Path = path };
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private List<Order> GetOrders(string FileName, Model Model)
        {
            try
            {
                List<Order> orders = new List<Order>();

                XDocument doc = XDocument.Load(FileName);

                int CountIter = 1;

                int CountDrawing = doc.Element("Export").Elements("Сборка").Count();

                notify.SetMaximum(CountDrawing);

                foreach (var assembly in doc.Element("Export").Elements("Сборка"))
                {
                    notify.Notify(CountIter, $"Обработка {CountIter} чертежа из {CountDrawing}");

                    string Number = assembly.Element("Заказ").Value.Replace(" ", "");
                    string List = assembly.Element("Лист").Value.Replace(" ", "");
                    string Mark = assembly.Element("Марка").Value.Replace(" ", "");
                    string Executor = assembly.Element("Разработчик_чертежа").Value.Replace(" ", "");
                    string Lenght = assembly.Element("Деталь").Element("Г.М_длина").Value.Replace(" ", "");
                    string Weight = assembly.Element("Масса_итого").Value.Replace(" ", "");

                    orders.Add(new Order(0, DateTime.Now, Number, Executor, "Исполнитель не определен", List, Mark, Convert.ToDouble(Lenght.Replace(".", ",")), Convert.ToDouble(Weight.Replace(".", ",")), null, DateTime.Now, null, Model, null, null, false, false));

                    orders[orders.Count - 1].CountMarks = Convert.ToInt32(assembly.Element("Кол_во_марок").Value.Replace(" ", ""));

                    GetDetails(orders[orders.Count - 1].Details, assembly);
                }

                return orders;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void GetDetails(List<Detail> details, XElement assembly)
        {
            try
            {
                foreach (var detail in assembly.Elements("Деталь"))
                {
                    long Position = Convert.ToInt32(detail.Element("Позиция_детали").Value.Replace(" ", ""));
                    long Count = Convert.ToInt32(detail.Element("Кол_во_деталей").Value.Replace(" ", ""));
                    string Profile = GetProfile(detail.Element("Профиль").Value.Replace(" ", ""), detail);
                    double Width = Convert.ToDouble(detail.Element("Ширина").Value.Replace(" ", "").Replace(".", ","));
                    double Lenght = Convert.ToDouble(detail.Element("Длина").Value.Replace(" ", "").Replace(".", ","));
                    double Weight = Convert.ToDouble(detail.Element("Масса1шт").Value.Replace(" ", "").Replace(".", ","));
                    double SubTotalWeight = Convert.ToDouble(detail.Element("Масса_всех").Value.Replace(" ", "").Replace(".", ","));
                    string MarkSteel = detail.Element("Марка_стали").Value.Replace(" ", "");
                    string Discription = detail.Element("Примечание").Value.Replace(" ", "");
                    string Machining = detail.Element("Мех.обр").Value.Replace(" ", "");
                    string MethodOfPaintingRAL = detail.Element("Способ_покраски_RAL").Value.Replace(" ", "");
                    double PaintingArea = Convert.ToDouble(detail.Element("Площадь_покраски").Value.Replace(" ", "").Replace(".", ","));

                    details.Add(new Detail { Position = Position, Count = Count, Profile = Profile, Width = Width, Lenght = Lenght, Weight = Weight, SubtotalWeight = SubTotalWeight, MarkSteel = MarkSteel, Discription = Discription, Machining = Machining, MethodOfPaintingRAL = MethodOfPaintingRAL, PaintingArea = PaintingArea });
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private string GetProfile(string Profile, XElement detail)
        {
            try
            {
                int Index = -1;
                string GostName = detail.Element("GOST_NAME").Value.Replace(" ", "");

                String[] Arguments = new String[] { "PL", "Утеплит", "Риф", "Сетка 50/50х2.5 В=1800", "ПВ", "ГОСТ 8509-93", "ГОСТ 8510-93", "PD", "Профиль(кв.)", "Профиль", "*" };
                for (int i = 0; i < Arguments.Length; i++)
                {
                    if (Arguments[i].IndexOf("ГОСТ") == -1)
                    {
                        if (Profile.IndexOf(Arguments[i]) != -1)
                        {
                            Index = i;
                            break;
                        }
                    }
                    else
                    {
                        if (GostName.IndexOf(Arguments[i]) != -1)
                        {
                            Index = i;
                            break;
                        }
                    }
                }
                switch (Index)
                {
                    case 0:
                        int var4 = Convert.ToInt32(Profile.Substring(2, Profile.IndexOf("x") - 2));
                        int var5 = Convert.ToInt32(Profile.Substring(1 + Profile.IndexOf("x"), Profile.Length - Profile.IndexOf("x") - 1));

                        if (var4 > var5)
                        {
                            return "-" + var5.ToString();
                        }
                        else
                        {
                            return "-" + var4.ToString();
                        }
                    case 1:
                        return detail.Element("Марка_стали").Value;
                    case 2:
                        return detail.Element("Марка_стали").Value;
                    case 3:
                        return "Сетка 50/50х2.5 В=1800";
                    case 4:
                        return detail.Element("Марка_стали").Value;
                    case 5:
                        return $"L{detail.Element("WIDTH").Value.Replace(" ", "")}x{detail.Element("FLANGE_THICKNESS_1").Value.Replace(" ", "")}";
                    case 6:
                        return $"L{detail.Element("WIDTH").Value.Replace(" ", "")}x{detail.Element("WIDTH").Value.Replace(" ", "")}x{detail.Element("FLANGE_THICKNESS_1").Value.Replace(" ", "")}";
                    case 7:
                        return $"Труба {detail.Element("DIAMETER").Value.Replace(" ", "")}x{detail.Element("PLATE_THICKNESS").Value.Replace(" ", "")}";
                    case 8:
                        return $"Тр.кв.{detail.Element("HEIGHT").Value.Replace(" ", "")}x{detail.Element("PLATE_THICKNESS").Value.Replace(" ", "")}";
                    case 9:
                        return $"Тр.пр.{detail.Element("HEIGHT").Value.Replace(" ", "")}x{detail.Element("HEIGHT").Value.Replace(" ", "")}x{detail.Element("PLATE_THICKNESS").Value.Replace(" ", "")}";
                    case 10:
                        return Profile.Replace("*", "x");
                }
                return Profile;
            }
            catch
            {
                return Profile;
            }
        }
        private TreeNode GetTreeNodeModel(Model Model, List<Order> IterOrders)
        {
            try
            {
                TreeNode tnModel = new TreeNode();
                tnModel.Text = "Модель: " + Model.Path;

                for (int i = 0; i < IterOrders.Count; i++)
                {
                    tnModel.Nodes.Add(GetTreeNodeOrder(IterOrders[i]));
                }

                return tnModel;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private TreeNode GetTreeNodeOrder(Order Order)
        {
            try
            {
                TreeNode Drawing = new TreeNode($"Номер: {Order.Number}, Лист: {Order.List}, Марка: {Order.Mark}");

                TreeNode Number = new TreeNode($"Номер: {Order.Number}");
                Drawing.Nodes.Add(Number);
                TreeNode List = new TreeNode($"Лист: {Order.List}");
                Drawing.Nodes.Add(List);
                TreeNode Mark = new TreeNode($"Марка: {Order.Mark}");
                Drawing.Nodes.Add(Mark);
                TreeNode Executor = new TreeNode($"Исполнитель: {Order.Executor}");
                Drawing.Nodes.Add(Executor);
                TreeNode Lenght = new TreeNode($"Длина: {Order.Lenght}");
                Drawing.Nodes.Add(Lenght);
                TreeNode Weight = new TreeNode($"Вес: {Order.Weight}");
                Drawing.Nodes.Add(Weight);

                Drawing.Nodes.Add(GetTreeNodeDetails(Order.Details));

                return Drawing;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private TreeNode GetTreeNodeDetails(List<Detail> Details)
        {
            try
            {
                TreeNode tnDetails = new TreeNode("Детали");

                for (int i = 0; i < Details.Count; i++)
                {
                    TreeNode Detail = new TreeNode($"Позиция: {Details[i].Position}");

                    TreeNode Count = new TreeNode($"Кол-во: {Details[i].Count}");
                    Detail.Nodes.Add(Count);
                    TreeNode Profile = new TreeNode($"Профиль: {Details[i].Profile}");
                    Detail.Nodes.Add(Profile);
                    TreeNode Width = new TreeNode($"Высота: {Details[i].Width}");
                    Detail.Nodes.Add(Width);
                    TreeNode Lenght = new TreeNode($"Длина: {Details[i].Lenght}");
                    Detail.Nodes.Add(Lenght);
                    TreeNode Weight = new TreeNode($"Вес: {Details[i].Weight}");
                    Detail.Nodes.Add(Weight);
                    TreeNode SubtotalWeight = new TreeNode($"Общий вес: {Details[i].SubtotalWeight}");
                    Detail.Nodes.Add(SubtotalWeight);
                    TreeNode MarkSteel = new TreeNode($"Марка стали: {Details[i].MarkSteel}");
                    Detail.Nodes.Add(MarkSteel);
                    TreeNode Discription = new TreeNode($"Примечание: {Details[i].Discription}");
                    Detail.Nodes.Add(Discription);
                    TreeNode Machining = new TreeNode($"Мех. обр.: {Details[i].Machining}");
                    Detail.Nodes.Add(Machining);
                    TreeNode MethodOfPaintingRAL = new TreeNode($"Способ покрасики RAL: {Details[i].MethodOfPaintingRAL}");
                    Detail.Nodes.Add(MethodOfPaintingRAL);
                    TreeNode PaintingArea = new TreeNode($"Площадь покраски: {Details[i].PaintingArea}");
                    Detail.Nodes.Add(PaintingArea);

                    tnDetails.Nodes.Add(Detail);
                }

                return tnDetails;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void CheckedData()
        {
            try
            {
                notify.SetMaximum(Orders.Count);
                OrderScanSession = new List<OrderScanSession>();
                for (int i = 0; i < Orders.Count; i++)
                {
                    notify.Notify(i, $"Проверка {i + 1} чертежа из {Orders.Count}");

                    SetResult(Orders[i], OrderScanSession);
                }
            }
            catch (Exception Ex)
            {
                notify.CloseAsync();
                OrderScanSession.Clear();
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
