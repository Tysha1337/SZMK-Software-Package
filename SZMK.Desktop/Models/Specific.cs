using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    /*Класс объект детали, хранящий информацию о детали с соответствующими полями*/
    public class Specific
    {
        private String _Number;
        private String _List;
        private Int64 _NumberSpecific;
        private Boolean _Finded;
        public Specific(String Number, String List, Int64 NumberSpecific, Boolean Finded)
        {
            if (!String.IsNullOrEmpty(Number))
            {
                _Number = Number;
            }
            else
            {
                throw new Exception("Не задан номер заказа");
            }
            if (!String.IsNullOrEmpty(List))
            {
                _List = List;
            }
            else
            {
                throw new Exception("Номер листа заказа меньше 0");
            }
            if (NumberSpecific >= 0)
            {
                _NumberSpecific = NumberSpecific;
            }
            else
            {
                throw new Exception("Номер детали меньше 0");
            }
            _Finded = Finded;
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
        public Int64 NumberSpecific
        {
            get
            {
                return _NumberSpecific;
            }
            set
            {
                if (value >= 0)
                {
                    _NumberSpecific = value;
                }
            }
        }
        public Boolean Finded
        {
            get
            {
                return _Finded;
            }
            set
            {
                _Finded = value;
            }
        }
    }
}
