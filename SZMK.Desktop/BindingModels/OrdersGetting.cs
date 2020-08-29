using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.BindingModels
{
    public class OrdersGetting
    {
        public Int64 ID { get; set; }
        public Status Status { get; set; }
        public DateTime DateStatus { get; set; }
        public User User { get; set; }
        public BlankOrder BlankOrder { get; set; }
    }
}
