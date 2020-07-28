using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class Status
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }

        public virtual ICollection<ModifyDrawing> ModifyDrawings { get; set; }
        public Status()
        {
            ModifyDrawings = new List<ModifyDrawing>();
        }
    }
}
