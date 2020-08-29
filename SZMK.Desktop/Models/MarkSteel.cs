using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class MarkSteel
    {
        private String _Name;
        private DateTime _DateCreate;
        private Int64 _ID;

        public MarkSteel(Int64 ID, DateTime DateCreate, String Name)
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
                throw new Exception("Дата создания не указана");
            }
            if (!String.IsNullOrEmpty(Name))
            {
                _Name = Name;
            }
            else
            {
                throw new Exception("Марка стали не указан");
            }
        }

        public MarkSteel() : this(0, DateTime.Now, "Марка стали не указан") { }

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
    }
}
