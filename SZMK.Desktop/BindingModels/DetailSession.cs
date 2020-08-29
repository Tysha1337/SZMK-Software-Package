using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.BindingModels
{
    public class DetailSession
    {
        private Int32 _IDOrder;
        private Detail _Detail;
        public DetailSession(Int32 IDOrder, Detail Detail)
        {
            if (IDOrder >= 0)
            {
                _IDOrder = IDOrder;
            }
            else
            {
                throw new Exception("ID чертежа меньше нуля");
            }
            if (Detail != null)
            {
                _Detail = Detail;
            }
            else
            {
                throw new Exception("Детали не существует");
            }
        }
        public DetailSession() : this(0, null) { }
        public Int32 IDOrder
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
        public Detail Detail
        {
            get
            {
                return _Detail;
            }
            set
            {
                if (value != null)
                {
                    _Detail = value;
                }
            }
        }
    }
}
