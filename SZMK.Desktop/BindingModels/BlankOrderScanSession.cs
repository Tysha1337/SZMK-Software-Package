using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.BindingModels
{
    /*Класс обертка созданный использования при создании листа с сессией сканирования бланков заказов*/
    public class BlankOrderScanSession
    {
        public struct NumberAndList
        {
            private String _Number;
            private String _List;
            private Int32 _Finded;

            public NumberAndList(String Number, String List, Int32 Finded)
            {
                if (!String.IsNullOrEmpty(Number))
                {
                    _Number = Number;
                }
                else
                {
                    throw new Exception("Пустое значение номера заказа");
                }
                if (!String.IsNullOrEmpty(List))
                {
                    _List = List;
                }
                else
                {
                    throw new Exception("Пустое значение листа");
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
            public Int32 Finded
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
        private bool _Added;
        private String _QRBlankOrder;
        private readonly List<NumberAndList> _Order;
        public BlankOrderScanSession(Boolean Added, String QRBlankOrder)
        {
            _Added = Added;
            if (!String.IsNullOrEmpty(QRBlankOrder))
            {
                _QRBlankOrder = QRBlankOrder;
            }
            else
            {
                throw new Exception("Пустое значение QR бланка заказа чертежа");
            }
            _Order = new List<NumberAndList>();
        }
        public BlankOrderScanSession() : this(false,"Нет QR бланка заказа") { }

        public Boolean Added
        {
            get
            {
                return _Added;
            }
            set
            {
                _Added = value;
            }
        }
        public String QRBlankOrder
        {
            get
            {
                return _QRBlankOrder;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _QRBlankOrder = value;
                }
            }
        }
        public NumberAndList this[int Index]
        {
            get
            {
                return _Order[Index];
            }
            set
            {
               _Order[Index] = value;
            }
        }
        public List<NumberAndList> GetNumberAndLists()
        {
            return _Order;
        }
    }
}
