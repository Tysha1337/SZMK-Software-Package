using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class TypeAdd
    {
        public long ID { get; set; }
        public DateTime DateCreate { get; set; }
        public string Discriprion { get; set; }
        public override String ToString()
        {
            return Discriprion;
        }
    }
}
