using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZMK.Domain.Models
{
    public class Detail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DrawingId { get; set; }
        public virtual Drawing Drawing { get; set; }

        public int Position { get; set; }
        public int Count { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public double Width { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public double SubtotalWeight { get; set; }

        public int MarkSteelId { get; set; }
        public virtual MarkSteel MarkSteel { get; set; }

        public string Discription { get; set; }
        public string Machining { get; set; }
        public string MethodOfPaintingRAL { get; set; }

        public double PaintingArea { get; set; }
    }
}
