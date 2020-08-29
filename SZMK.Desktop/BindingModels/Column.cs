using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.BindingModels
{
    public class Column
    {
        private String _Name;
        private Boolean _Visible;
        private Int32 _DisplayIndex;
        private float _FillWeight;

        public Column(String Name, Boolean Visible, Int32 DisplayIndex, float FillWeight)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                _Name = Name;
            }
            else
            {
                throw new Exception("Пустое значение имени столбца");
            }
            _Visible = Visible;
            if (DisplayIndex >= 0)
            {
                _DisplayIndex = DisplayIndex;
            }
            else
            {
                throw new Exception("Значение отображения столбца меньше 0");
            }
            if (FillWeight >= 0)
            {
                _FillWeight = FillWeight;
            }
            else
            {
                throw new Exception("Значение ширины столбца меньше 0");
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
                    _Name = Name;
                }
            }
        }
        public Boolean Visible
        {
            get
            {
                return _Visible;
            }
            set
            {
                _Visible = value;
            }
        }
        public Int32 DisplayIndex
        {
            get
            {
                return _DisplayIndex;
            }
            set
            {
                if (value >= 0)
                {
                    _DisplayIndex = value;
                }
            }
        }
        public float FillWeight
        {
            get
            {
                return _FillWeight;
            }
            set
            {
                if (value >= 0)
                {
                    _FillWeight = value;
                }
            }
        }
    }
}
