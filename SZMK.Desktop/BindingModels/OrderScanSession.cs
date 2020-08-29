using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.BindingModels
{
    /*Класс обертка для создания листа с данными отсканированных чертежей в текущей сессии*/
    public class OrderScanSession
    {
        private String _DateMatrix;
        private Int32 _Unique;
        private String _Discription;
        public OrderScanSession(String DataMatrix, Int32 Unique,String Discription)
        {
            if(!String.IsNullOrEmpty(DataMatrix))
            {
                _DateMatrix = DataMatrix;
            }
            else
            {
                throw new Exception("Пустое значение DataMatrix чертежа");
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
        public OrderScanSession() : this("Нет DataMatrix", 0,"Проблем нет") { }
        public String DataMatrix
        {
            get
            {
                return _DateMatrix;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _DateMatrix = value;
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
