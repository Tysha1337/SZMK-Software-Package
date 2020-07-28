using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class Mail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }
        public DateTime DateModify { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string MidName { get; set; }
        public string SureName { get; set; }
    }
}
