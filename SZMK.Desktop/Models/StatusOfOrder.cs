using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    /*Данный класс описывает структуру связной таблицы, в которую добавляются данные при добавлении статуса чертежу*/
    public class StatusOfOrder
    {
        private DateTime _DateCreate;
        private Int64 _IDStatus;
        private Int64 _IDOrder;
        private Int64 _IDUser;

        public StatusOfOrder(DateTime DateCreate, Int64 IDStatus, Int64 IDOrder, Int64 IDUser)
        {
            if (DateCreate != null)
            {
                _DateCreate = DateCreate;
            }
            else
            {
                throw new Exception("Пустое значение даты добавления статуса");
            }
            if (IDStatus >= 0)
            {
                _IDStatus = IDStatus;
            }
            else
            {
                throw new Exception("ИД статуса должен быть больше 0");
            }
            if (IDOrder >= 0)
            {
                _IDOrder = IDOrder;
            }
            else
            {
                throw new Exception("ИД чертежа должен быть больше 0");
            }
            if (IDUser >= 0)
            {
                _IDUser = IDUser;
            }
            else
            {
                throw new Exception("ИД пользователя должен быть больше 0");
            }
        }
        public StatusOfOrder() : this(DateTime.Now, -1, -1,-1) { }
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
        public Int64 IDStatus
        {
            get
            {
                return _IDStatus;
            }

            set
            {
                if (value >= 0)
                {
                    _IDStatus = value;
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
        public Int64 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                if (value >= 0)
                {
                    _IDUser = value;
                }
            }
        }
    }
}
