using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.BindingModels
{
    public class DecodeScanSession
    {
        private String _DateMatrix;
        private Int32 _Unique;
        public DecodeScanSession(String DataMatrix, Int32 Unique)
        {
            if (!String.IsNullOrEmpty(DataMatrix))
            {
                _DateMatrix = DataMatrix;
            }
            else
            {
                throw new Exception("Пустое значение DataMatrix чертежа");
            }
            if (Unique < 2 && Unique > -2)
            {
                _Unique = Unique;
            }
            else
            {
                throw new Exception("Ошибка значения уникальности");
            }
        }
        public DecodeScanSession() : this("Нет DataMatrix", -1) { }
        public String DataMatrix
        {
            get
            {
                return _DateMatrix;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _DateMatrix = value;
                }
            }
        }
        public Int32 Unique
        {
            get
            {
                return _Unique;
            }
            set
            {
                if (Unique < 2 && Unique > -2)
                {
                    _Unique = value;
                }
            }
        }
    }
}
