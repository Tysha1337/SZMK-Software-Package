using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class ModifyDrawing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int DrawingId { get; set; }
        public virtual Drawing Drawing { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
