using System;

namespace SZMK.TeklaInteraction.Shared.Models
{
    public class Role
    {
        private String _Name;
        private Int64 _ID;

        public Role(Int64 ID, String Name)
        {
            if (ID > 0)
            {
                _ID = ID;
            }
            else
            {
                throw new Exception("ID позиции должно быть больше 0");
            }

            if (!String.IsNullOrEmpty(Name))
            {
                _Name = Name;
            }
            else
            {
                throw new Exception("Путое наименование позиции");
            }
        }

        public Role() : this(0, "Без наименования позиции") { }

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

        public override String ToString()
        {
            return _Name;
        }
    }
}
