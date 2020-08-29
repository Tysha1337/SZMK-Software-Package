using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class Position : BasePosition
    {
        private String _Name;
        private Int64 _ID;

        public Position(Int64 ID, String Name) : base(ID)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                _Name = Name;
            }
        }

        public Position() : this(0, "Без наименования позиции") { }

        public override Int64 ID
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
