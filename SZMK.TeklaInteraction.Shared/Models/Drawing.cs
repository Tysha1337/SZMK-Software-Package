using System.Collections.Generic;

namespace SZMK.TeklaInteraction.Shared.Models
{
    public class Drawing
    {
        public long Id { get; set; }
        public string DataMatrix { get; set; }
        public string Assembly { get; set; }
        public string Order { get; set; }
        public string Place { get; set; }
        public string List { get; set; }
        public string Mark { get; set; }
        public string Executor { get; set; }
        public double WeightMark { get; set; }
        public int CountMark { get; set; }
        public double SubTotalWeight { get; set; }
        public int CountDetail { get; set; }
        public List<Detail> Details { get; set; }
        public override string ToString()
        {
            return DataMatrix;
        }
    }
}
