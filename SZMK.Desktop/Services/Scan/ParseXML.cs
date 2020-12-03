using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.Desktop.BindingModels;
using SZMK.Desktop.Models;
using SZMK.Desktop.ViewModel;
using SZMK.Desktop.Views.Shared;
using SZMK.Desktop.Views.Shared.Interfaces;

namespace SZMK.Desktop.Services.Scan
{
    public class ParseXML : BaseScanOrder
    {
        private INotifyProcess notify;
        public List<Order> Orders { get; set; }
        public List<StringErrorBindingModels> ErrorOrders { get; set; }
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
                Orders = GetOrders(FileName, Model);

                TreeNodes.Add(GetTreeNodeModel(Model, Orders));
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
                List<Order> SucsessfulOrders = new List<Order>();
                ErrorOrders = new List<StringErrorBindingModels>();

                XDocument doc = XDocument.Load(FileName);

                int CountIter = 1;

                int CountDrawing = doc.Element("Export").Elements("Сборка").Count();

                notify.SetMaximum(CountDrawing);
                string Number = "";
                string List = "";
                string Mark = "";
                string Executor = "";
                string Lenght = "";
                string Weight = "";
                string CountMarks = "";
                string Error = "";

                foreach (var assembly in doc.Element("Export").Elements("Сборка"))
                {
                    notify.Notify(CountIter, $"Обработка {CountIter} чертежа из {CountDrawing}");

                    try
                    {
                        Error = "Заказ";
                        Number = assembly.Element("Заказ").Value.Replace(" ", "");
                        Error = "Лист";
                        List = assembly.Element("Лист").Value.Replace(" ", "");
                        Error = "Марка";
                        Mark = assembly.Element("Марка").Value.Replace(" ", "");
                        Error = "Разработчик_чертежа";
                        Executor = assembly.Element("Разработчик_чертежа").Value.Replace(" ", "");
                        Error = "Г.М_длина";
                        Lenght = assembly.Element("Деталь").Element("Г.М_длина").Value.Replace(" ", "");
                        Error = "Масса_итого";
                        Weight = assembly.Element("Масса_итого").Value.Replace(" ", "");
                        Error = "Кол_во_марок";
                        CountMarks = assembly.Element("Кол_во_марок").Value.Replace(" ", "");

                        Order CheckedOrder = new Order(0, DateTime.Now, Number, Executor, "Исполнитель не определен", List, Mark, Lenght, Weight, null, DateTime.Now, null, Model, null, null, false, false, CountMarks, new List<Detail>());

                        GetDetails(CheckedOrder.Details, assembly);

                        SucsessfulOrders.Add(CheckedOrder);
                    }
                    catch (NullReferenceException Ex)
                    {
                        ErrorOrders.Add(new StringErrorBindingModels { Data = $"В отчете чертеж под номером: {CountIter}", Error = $"Отсутвует поле {Error}" });
                    }
                    catch (Exception Ex)
                    {
                        ErrorOrders.Add(new StringErrorBindingModels { Data = $"Номер заказа:{Number.Trim()}, Лист:{List.Trim()}", Error = Ex.Message });
                    }
                }

                return SucsessfulOrders;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void GetDetails(List<Detail> details, XElement assembly)
        {
            string Error = "";

            try
            {
                foreach (var detail in assembly.Elements("Деталь"))
                {
                    Error = "Позиция_детали";
                    string Position = detail.Element("Позиция_детали").Value;

                    Error = "Кол_во_деталей";
                    string Count = detail.Element("Кол_во_деталей").Value;

                    Error = "Профиль";
                    string Profile = detail.Element("Профиль").Value;

                    Error = "Ширина";
                    string Width = detail.Element("Ширина").Value;

                    Error = "Длина";
                    string Lenght = detail.Element("Длина").Value;

                    Error = "Масса1шт";
                    string Weight = detail.Element("Масса1шт").Value;

                    Error = "HEIGHT";
                    string Height = detail.Element("HEIGHT").Value;

                    Error = "DIAMETER";
                    string Diameter = detail.Element("DIAMETER").Value;

                    Error = "Масса_всех";
                    string SubtotalWeight = detail.Element("Масса_всех").Value;

                    Error = "Марка_стали";
                    string MarkSteel = detail.Element("Марка_стали").Value;

                    Error = "Примечание";
                    string Discription = detail.Element("Примечание").Value;

                    Error = "Мех.обр";
                    string Machining = detail.Element("Мех.обр").Value;

                    Error = "Способ_покраски_RAL";
                    string MethodOfPaintingRAL = detail.Element("Способ_покраски_RAL").Value;

                    Error = "Площадь_покраски";
                    string PaintingArea = detail.Element("Площадь_покраски").Value;

                    Error = "GOST_NAME";
                    string GostName = detail.Element("GOST_NAME").Value;

                    Error = "FLANGE_THICKNESS_1";
                    string FlangeThickness = detail.Element("FLANGE_THICKNESS_1").Value;

                    Error = "PLATE_THICKNESS";
                    string PlateThickness = detail.Element("PLATE_THICKNESS").Value;

                    DetailViewModel detailViewModel = new DetailViewModel(
                        Position,
                        Count,
                        Profile,
                        Width,
                        Lenght,
                        Weight,
                        Height,
                        Diameter,
                        SubtotalWeight,
                        MarkSteel,
                        Discription,
                        Machining,
                        MethodOfPaintingRAL,
                        PaintingArea,
                        GostName,
                        FlangeThickness,
                        PlateThickness
                        );

                    details.Add(new Detail
                    {
                        Position = detailViewModel.Position,
                        Count = detailViewModel.Count,
                        Profile = detailViewModel.Profile,
                        Width = detailViewModel.Width,
                        Lenght = detailViewModel.Lenght,
                        Weight = detailViewModel.Weight,
                        Height = detailViewModel.Height,
                        Diameter = detailViewModel.Diameter,
                        SubtotalWeight = detailViewModel.SubTotalWeight,
                        MarkSteel = detailViewModel.MarkSteel,
                        Discription = detailViewModel.Discription,
                        Machining = detailViewModel.Machining,
                        MethodOfPaintingRAL = detailViewModel.MethodOfPaintiongRAL,
                        PaintingArea = detailViewModel.PaintingArea,
                        GostName = detailViewModel.GostName,
                        FlangeThickness = detailViewModel.FlangeThickness,
                        PlateThickness = detailViewModel.PlateThickness
                    });
                }
            }
            catch (NullReferenceException Ex)
            {
                throw new Exception($"В детали Отсутвует поле: {Error}");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
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

                    SetResult(Orders[i], OrderScanSession, true);
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
