using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    /*Данный класс описывает справочник статусов, в котором содержится id, id должности к которой он принадлежит, а также наименование самого статуса*/
    public class Status : IComparable<Status>
    {
        private Int64 _ID;
        private Int64 _IDPosition;
        private String _Name;

        public Status(Int64 ID, Int64 IDPosition, String Name)
        {
            _ID = ID;

            if (IDPosition >= 0)
            {
                _IDPosition = IDPosition;
            }
            else
            {
                throw new Exception("Значение id позиции меньше 0");
            }

            if (!String.IsNullOrEmpty(Name))
            {
                _Name = Name;
            }
            else
            {
                throw new Exception("Пустое значение наименования статуса");
            }
        }

        public Status() : this(0, 0, "Нет наименования статуса") { }

        public Int64 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public Int64 IDPosition
        {
            get
            {
                return _IDPosition;
            }
            set
            {
                if (value >= 0)
                {
                    _IDPosition = value;
                }
            }
        }

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Name = value;
                }
            }

        }
        public override string ToString()
        {
            return _Name;
        }


        public int CompareTo(Status status)
        {
            if (status != null)
                return this.Name.CompareTo(status.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
