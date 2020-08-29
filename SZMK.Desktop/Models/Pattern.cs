using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class Pattern
    {
        private String _Path;
        private Int64 _ID;

        public Pattern(Int64 ID, String Path)
        {
            if (ID >= 0)
            {
                _ID = ID;
            }

            if (!String.IsNullOrEmpty(Path))
            {
                _Path = Path;
            }
            else
            {
                throw new Exception("Модель не указана");
            }
        }

        public Pattern() : this(0, "Модель не указана") { }

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

        public String Path
        {
            get
            {
                return _Path;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Path = value;
                }
            }
        }
    }
}
