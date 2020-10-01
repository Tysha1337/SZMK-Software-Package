using System;
using System.Collections.Generic;

namespace SZMK.TeklaInteraction.Shared.Models
{
    public class Model
    {
        public long Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string Path { get; set; }
        public List<Drawing> Drawings { get; set; }
    }
}
