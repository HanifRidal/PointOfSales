using System.ComponentModel.DataAnnotations;

namespace PointOfSales.Models.Domain
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } //null-forgiving op.
        [StringLength(1000)]
        public string? Description { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }

        //[ForeignKey("Category")]
        public virtual Category? Category { get; set; }
    }
}
