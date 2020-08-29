using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    /*Класс объект бланка заказа со всеми присущими ему полями*/
    public class BlankOrder
    {
        private Int64 _ID;
        private DateTime _DateCreate;
        private String _QR;
        public BlankOrder(Int64 ID, DateTime DateCreate, String QR)
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
                throw new Exception("Пустое значение даты создания");
            }

            if (!String.IsNullOrEmpty(QR))
            {
                _QR = QR;
            }
            else
            {
                throw new Exception("Пустое значение QR бланка заказа");
            }
        }
        public BlankOrder() : this(0, DateTime.Now, "Нет QR бланка заказа") { }
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
        public String QR
        {
            get
            {
                return _QR;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _QR = value;
                }
            }
        }
        public override String ToString()
        {
            return _QR;
        }
    }
}
