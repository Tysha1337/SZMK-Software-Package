using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    /*Класс для создания листа хранения данных связной таблицы между справочником бланков заказов и чертежами*/
    public class BlankOrderOfOrder
    {
        public DateTime _DateCreate;
        public Int64 _IDBlankOrder;
        public Int64 _IDOrder;

        public BlankOrderOfOrder(DateTime DateCreate, Int64 IDBlankOrder, Int64 IDOrder)
        {
            if (DateCreate != null)
            {
                _DateCreate = DateCreate;
            }
            else
            {
                throw new Exception("Пустое значение даты добавления статуса");
            }
            if (IDBlankOrder >= 0)
            {
                _IDBlankOrder = IDBlankOrder;
            }
            else
            {
                throw new Exception("ИД бланка заказа должен быть больше 0");
            }
            if (IDOrder >= 0)
            {
                _IDOrder = IDOrder;
            }
            else
            {
                throw new Exception("ИД чертежа должен быть больше 0");
            }
        }
        public BlankOrderOfOrder() : this(DateTime.Now, -1, -1) { }
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
        public Int64 IDBlankOrder
        {
            get
            {
                return _IDBlankOrder;
            }

            set
            {
                if (value >= 0)
                {
                    _IDBlankOrder = value;
                }
            }
        }
        public Int64 IDOrder
        {
            get
            {
                return _IDOrder;
            }

            set
            {
                if (value >= 0)
                {
                    _IDOrder = value;
                }
            }
        }
    }
}
