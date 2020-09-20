using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.BindingModels
{
    /*Класс обертка для создания листа с данными отсканированных чертежей в текущей сессии*/
    public class OrderScanSession
    {
        private Order _Order;
        private Int32 _Unique;
        private String _Discription;
        public OrderScanSession(Order Order, Int32 Unique,String Discription)
        {
            if(Order!=null)
            {
                _Order = Order;
            }
            else
            {
                throw new Exception("Пустое значение чертежа");
            }
            if (Unique >= 0)
            {
                _Unique = Unique;
            }
            else
            {
                throw new Exception("Значение уникальности не может быть меньше 0");
            }
            if (!String.IsNullOrEmpty(Discription))
            {
                _Discription = Discription;
            }
            else
            {
                throw new Exception("Пустое значение описания чертежа");
            }
        }
        public OrderScanSession() : this(null, 0,"Проблем нет") { }
        public Order Order
        {
            get
            {
                return _Order;
            }
            set
            {
                if (value != null)
                {
                    _Order = value;
                }
            }
        }
        public Int32 Unique
        {
            get
            {
                return _Unique;
            }
            set
            {
                if (value >= 0)
                {
                    _Unique = value;
                }
            }
        }
        public String Discription
        {
            get
            {
                return _Discription;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Discription = value;
                }
            }
        }

    }
}
