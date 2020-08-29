using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public abstract class BasePosition
    {
        abstract public Int64 ID { get; set; }

        public BasePosition(Int64 ID)
        {
            this.ID = ID;
        }

        public BasePosition() : this(-1) { }
    }
}
