using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class BlankOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Drawing> Drawings { get; set; }
        public BlankOrder()
        {
            Drawings = new List<Drawing>();
        }
    }
}
