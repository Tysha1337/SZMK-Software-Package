using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class MarkSteel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
        public MarkSteel()
        {
            Details = new List<Detail>();
        }
    }
}