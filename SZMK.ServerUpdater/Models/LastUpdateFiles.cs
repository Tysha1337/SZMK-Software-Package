using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.ServerUpdater.Models
{
    public class LastUpdateFiles
    {
        public string FileName { get; set; }
        public string Hash { get; set; }
        public bool NeedUpdate { get; set; }
    }
}
