using System;

namespace SZMK.TeklaInteraction.Shared.Models
{
    public class Status
    {
        private Int64 _ID;
        private Int64 _IDRole;
        private String _Name;

        public Status(Int64 ID, Int64 IDRole, String Name)
        {
            _ID = ID;

            if (IDRole >= 0)
            {
                _IDRole = IDRole;
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

        public Int64 IDRole
        {
            get
            {
                return _IDRole;
            }
            set
            {
                if (value >= 0)
                {
                    _IDRole = value;
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
    }
}
