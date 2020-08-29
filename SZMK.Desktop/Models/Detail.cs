using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class Detail
    {
        private Int64 _ID;
        private String _Profile;
        private Double _SubtotalWeight;
        private String _MarkSteel;

        public Detail(Int64 ID, String Profile, Double SubtotalWeight, String MarkSteel)
        {
            if (ID >= 0)
            {
                _ID = ID;
            }
            else
            {
                throw new Exception("ID детали меньше нуля");
            }
            if (!String.IsNullOrEmpty(Profile))
            {
                _Profile = Profile;
            }
            else
            {
                throw new Exception("Пустое значение профиля детали");
            }
            if (SubtotalWeight >= 0)
            {
                _SubtotalWeight = SubtotalWeight;
            }
            else
            {
                throw new Exception("Ширина детали меньше нуля");
            }
            if (!String.IsNullOrEmpty(MarkSteel))
            {
                _MarkSteel = MarkSteel;
            }
            else
            {
                throw new Exception("Пустое значение марки стали");
            }
        }

        public Detail() : this(0, null, 0, null) { }

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
        public String Profile
        {
            get
            {
                return _Profile;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Profile = value;
                }
            }
        }
        public Double SubtotalWeight
        {
            get
            {
                return _SubtotalWeight;
            }

            set
            {
                if (value >= 0)
                {
                    _SubtotalWeight = value;
                }
            }
        }
        public String MarkSteel
        {
            get
            {
                return _MarkSteel;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _MarkSteel = value;
                }
            }
        }
    }
}
