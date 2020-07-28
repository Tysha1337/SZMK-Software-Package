using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class Model
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string Path { get; set; }

        public virtual ICollection<Drawing> Drawings { get; set; }
        public Model()
        {
            Drawings = new List<Drawing>();
        }
    }
}
