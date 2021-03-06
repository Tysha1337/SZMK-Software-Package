﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class Detail
    {
        public long ID { get; set; }
        public long Position { get; set; }
        public long Count { get; set; }
        public string Profile { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Diameter { get; set; }
        public double SubtotalWeight { get; set; }
        public string MarkSteel { get; set; }
        public string Discription { get; set; }
        public string Machining { get; set; }
        public string MethodOfPaintingRAL { get; set; }
        public double PaintingArea { get; set; }
        public string GostName { get; set; }
        public string FlangeThickness { get; set; }
        public string PlateThickness { get; set; }
    }
}
