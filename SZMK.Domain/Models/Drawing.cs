using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class Drawing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ModelId { get; set; }
        public virtual Model Model { get; set; }

        public string Order { get; set; }
        public string Place { get; set; }
        public string List { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Developer { get; set; }
        public double WeightMark { get; set; }
        public int CountMark { get; set; }
        public double SubtotalWeight { get; set; }
        public int CountDetail { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public bool Canceled { get; set; }
        public bool Finished { get; set; }
        public string ExecutorWork { get; set; }
        public virtual ICollection<BlankOrder> BlankOrders { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<ModifyDrawing> ModifyDrawings { get; set; }
        public Drawing()
        {
            BlankOrders = new List<BlankOrder>();
            Details = new List<Detail>();
            ModifyDrawings = new List<ModifyDrawing>();
        }
    }
}
