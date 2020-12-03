using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    /*Класс реализует объек чертежа со всеми полями присущими чертежу*/
    public class Order
    {
        private Int64 _ID;
        private DateTime _DateCreate;
        private String _Number;
        private String _Executor;
        private String _ExecutorWork;
        private String _List;
        private String _Mark;
        private Int32 _CountMarks;
        private Double _Lenght;
        private Double _Weight;
        private Status _Status;
        private DateTime _StatusDate;
        private BlankOrder _BlankOrder;
        private String _BlankOrderView;
        private TypeAdd _TypeAdd;
        private Model _Model;
        private List<Detail> _Details;
        private User _User;
        private Boolean _Canceled;
        private Boolean _Finished;


        public Order(Int64 ID, DateTime DateCreate, String Number, String Executor, String ExecutorWork, String List, String Mark, Double Lenght, Double Weight, Status Status, DateTime StatusDate, TypeAdd TypeAdd, Model Model, User User, BlankOrder BlankOrder, Boolean Canceled, Boolean Finished)
        {
            if (ID >= 0)
            {
                _ID = ID;
            }

            if (DateCreate != null)
            {
                _DateCreate = DateCreate;
            }
            else
            {
                throw new Exception("Пустое значение Даты добавления");
            }

            if (!String.IsNullOrEmpty(Number))
            {
                _Number = Number;
            }
            else
            {
                throw new Exception("Пустое значение Номера заказа");
            }

            if (!String.IsNullOrEmpty(Executor))
            {
                _Executor = Executor;
            }
            else
            {
                throw new Exception("Пустое значение Исполнителя");
            }
            if (!String.IsNullOrEmpty(ExecutorWork))
            {
                _ExecutorWork = ExecutorWork;
            }
            else
            {
                throw new Exception("Пустое значение Исполнителя работ");
            }

            if (!String.IsNullOrEmpty(List))
            {
                _List = List;
            }
            else
            {
                throw new Exception("Пустое значение листа");
            }

            if (!String.IsNullOrEmpty(Mark))
            {
                _Mark = Mark;
            }
            else
            {
                throw new Exception("Пустое значение Марки");
            }

            if (Lenght >= 0)
            {
                _Lenght = Lenght;
            }
            else
            {
                throw new Exception("Значение длинны меньше 0");
            }

            if (Weight >= 0)
            {
                _Weight = Weight;
            }
            else
            {
                throw new Exception("Значение веса меньше 0");
            }

            if (TypeAdd != null)
            {
                _TypeAdd = TypeAdd;
            }
            else
            {
                _TypeAdd = new TypeAdd { ID = 0, Discriprion = "Не определен" };
            }

            if (Model != null)
            {
                _Model = Model;
            }
            else
            {
                _Model = new Model { ID = 0, DateCreate = DateTime.Now, Path = "Путь не определен" };
            }

            _Details = new List<Detail>();

            if (StatusDate != null)
            {
                _StatusDate = StatusDate;
            }
            else
            {
                throw new Exception("Пустое значение даты присвоения статуса");
            }

            this.Status = Status;
            this.User = User;
            this.BlankOrder = BlankOrder;

            _Canceled = Canceled;

            _Finished = Finished;
        }
        public Order(Int64 ID, DateTime DateCreate, String Number, String Executor, String ExecutorWork, String List, String Mark, String Lenght, String Weight, Status Status, DateTime StatusDate, TypeAdd TypeAdd, Model Model, User User, BlankOrder BlankOrder, Boolean Canceled, Boolean Finished, String CountMarks, List<Detail> Details)
        {
            string Error = "";
            try
            {
                if (ID >= 0)
                {
                    _ID = ID;
                }

                if (DateCreate != null)
                {
                    _DateCreate = DateCreate;
                }
                else
                {
                    Error = "Пустое значение Даты добавления";
                    throw new Exception();
                }

                if (!String.IsNullOrEmpty(Number))
                {
                    _Number = Number;
                }
                else
                {
                    Error = "Пустое значение Номера заказа";
                    throw new Exception();
                }

                if (!String.IsNullOrEmpty(List))
                {
                    _List = List;
                }
                else
                {
                    Error = "Пустое значение листа";
                    throw new Exception();
                }

                if (!String.IsNullOrEmpty(Mark))
                {
                    _Mark = Mark;
                }
                else
                {
                    Error = "Пустое значение Марки";
                    throw new Exception();
                }

                if (!String.IsNullOrEmpty(Executor))
                {
                    _Executor = Executor;
                }
                else
                {
                    Error = "Пустое значение Исполнителя";
                    throw new Exception();
                }
                if (!String.IsNullOrEmpty(ExecutorWork))
                {
                    _ExecutorWork = ExecutorWork;
                }
                else 
                { 
                    Error = "Пустое значение Исполнителя работ";
                    throw new Exception();
                }

                Error = "Длина чертежа должна быть целым или вещественным числом";
                _Lenght = Convert.ToDouble(Lenght.Replace(" ", "").Replace(".", ","));

                Error = "Вес чертежа должна быть целым или вещественным числом";
                _Weight = Convert.ToDouble(Weight.Replace(" ", "").Replace(".", ","));

                Error = "Количество марок чертежа должно быть целым или вещественным числом";
                _CountMarks = Convert.ToInt32(CountMarks.Replace(" ", ""));

                _Status = Status;

                if (StatusDate != null)
                {
                    _StatusDate = StatusDate;
                }
                else
                {
                    Error = "Пустое значение даты присвоения статуса";
                    throw new Exception();
                }
                if (TypeAdd != null)
                {
                    _TypeAdd = TypeAdd;
                }
                else
                {
                    _TypeAdd = new TypeAdd { ID = 0, Discriprion = "Не определен" };
                }

                if (Model != null)
                {
                    _Model = Model;
                }
                else
                {
                    _Model = new Model { ID = 0, DateCreate = DateTime.Now, Path = "Путь не определен" };
                }

                _User = User;
                _BlankOrder = BlankOrder;
                _Canceled = Canceled;
                _Finished = Finished;
                _Details = Details;
            }
            catch
            {
                throw new Exception(Error);
            }
        }
        public Order(Order Order)
        {
            try
            {
                _DateCreate = Order.DateCreate;
                _Number = Order.Number;
                _Executor = Order.Executor;
                _ExecutorWork = Order.ExecutorWork;
                _List = Order.List;
                _Mark = Order.Mark;
                _Lenght = Order.Lenght;
                _Weight = Order.Weight;
                _Status = Order.Status;
                _StatusDate = Order.StatusDate;
                _TypeAdd = Order.TypeAdd;
                _Model = Order.Model;
                _User = Order.User;
                _BlankOrder = Order.BlankOrder;
                _Finished = Order.Finished;
                _Canceled = Order.Canceled;
                _CountMarks = Order.CountMarks;
                _Details = Details;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public Order() : this(-1, DateTime.Now, "Нет номера заказа", "Нет исполнителя", "Нет исполнителя работ", "Нет листа", "Нет марки", -1, -1, null, DateTime.Now, null, null, null, null, false, false) { }

        public Int64 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value >= 0)
                {
                    _ID = value;
                }
            }
        }

        public DateTime DateCreate
        {
            get
            {
                return _DateCreate;
            }
            set
            {
                if (value != null)
                {
                    _DateCreate = value;
                }
            }
        }

        public String Executor
        {
            get
            {
                return _Executor;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Executor = value;
                }
            }
        }

        public String ExecutorWork
        {
            get
            {
                return _ExecutorWork;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _ExecutorWork = value;
                }
            }
        }

        public String Number
        {
            get
            {
                return _Number;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Number = value;
                }
            }
        }

        public String List
        {
            get
            {
                return _List;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _List = value;
                }
            }
        }

        public String Mark
        {
            get
            {
                return _Mark;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Mark = value;
                }
            }
        }

        public Double Lenght
        {
            get
            {
                return _Lenght;
            }
            set
            {
                if (value >= 0)
                {
                    _Lenght = value;
                }
            }
        }

        public Double Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                if (value >= 0)
                {
                    _Weight = value;
                }
            }
        }

        public Status Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (value != null)
                {
                    _Status = value;
                }
            }
        }

        public DateTime StatusDate
        {
            get
            {
                return _StatusDate;
            }
            set
            {
                if (value != null)
                {
                    _StatusDate = value;
                }
            }
        }
        public TypeAdd TypeAdd
        {
            get
            {
                return _TypeAdd;
            }
            set
            {
                if (value != null)
                {
                    _TypeAdd = value;
                }
            }
        }
        public Model Model
        {
            get
            {
                return _Model;
            }
            set
            {
                if (value != null)
                {
                    _Model = value;
                }
            }
        }
        public List<Detail> Details
        {
            get
            {
                return _Details;
            }
        }

        public User User
        {
            get
            {
                return _User;
            }
            set
            {
                if (value != null)
                {
                    _User = value;
                }
            }
        }

        public String UserView
        {
            get
            {
                return _User.Surname + " " + _User.Name.First() + ". " + _User.MiddleName.First() + ".";
            }
        }

        public String BlankOrderView
        {
            get
            {
                return _BlankOrderView;
            }
        }

        public BlankOrder BlankOrder
        {
            get
            {
                return _BlankOrder;
            }
            set
            {
                if (value != null)
                {
                    _BlankOrder = value;

                    String[] Temp = _BlankOrder.QR.Split('_');
                    if (Temp.Length > 1)
                    {
                        Regex regex = new Regex(@"\d*-\d*-\d*");
                        MatchCollection matches = regex.Matches(Temp[1]);
                        if (matches.Count > 0)
                        {
                            _BlankOrderView = _BlankOrder.QR.Split('_')[1];
                        }
                        else
                        {
                            _BlankOrderView = _BlankOrder.QR.Split('_')[2];
                        }
                    }
                    else
                    {
                        _BlankOrderView = _BlankOrder.QR;
                    }
                }
            }
        }

        public Boolean Canceled
        {
            get
            {
                return _Canceled;
            }
            set
            {
                _Canceled = value;
            }
        }

        public String CanceledView
        {
            get
            {
                if (_Canceled)
                {
                    return "Да";
                }
                else
                {
                    return "Нет";
                }
            }
        }
        public Boolean Finished
        {
            get
            {
                return _Finished;
            }
            set
            {
                _Finished = value;
            }
        }

        public String FinishedView
        {
            get
            {
                if (_Finished)
                {
                    return "Да";
                }
                else
                {
                    return "Нет";
                }
            }
        }

        public int CountMarks
        {
            get
            {
                return _CountMarks;
            }
            set
            {
                if (value > 0)
                {
                    _CountMarks = value;
                }
            }
        }

        public String SearchString() => $"{ToString()}_{ExecutorWork}_{_Status.Name}_{_BlankOrder}_{_DateCreate}_{_User.Name}_{_User.MiddleName}_{_User.Surname}_{SystemArgs.StatusOfOrders.Where(p => p.IDOrder == _ID && p.IDStatus == _Status.ID).Select(p => p.DateCreate)}";

        public override string ToString()
        {
            return $"{_Number}_{_List}_{_Mark}_{_Executor}_{_Lenght}_{_Weight}";
        }
    }
}
