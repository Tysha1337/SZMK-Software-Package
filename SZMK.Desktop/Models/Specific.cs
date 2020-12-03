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
        private string _NumberSpecific;
        private string _PathDetails;
        private Boolean _Finded;
        public Specific(String Number, String List, string NumberSpecific, string PathDetails, Boolean Finded)
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
            if (!String.IsNullOrEmpty(NumberSpecific))
            {
                _NumberSpecific = NumberSpecific;
            }
            else
            {
                throw new Exception("Номер детали не заполнен");
            }
            if (!String.IsNullOrEmpty(PathDetails))
            {
                _PathDetails = PathDetails;
            }
            else
            {
                throw new Exception("Путь до деталей не заполнен");
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
        public string NumberSpecific
        {
            get
            {
                return _NumberSpecific;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _NumberSpecific = value;
                }
            }
        }
        public string PathDetails
        {
            get
            {
                return _PathDetails;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _PathDetails = value;
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
