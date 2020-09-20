using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class Model
    {
        public long ID { get; set; }
        public DateTime DateCreate { get; set; }
        public string Path { get; set; }
        public override String ToString()
        {
            return Path;
        }
    }
}
