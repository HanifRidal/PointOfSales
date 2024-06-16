using System.ComponentModel.DataAnnotations;

namespace PointOfSales.Models.Domain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        public virtual ICollection<Product>? Product { get; set; }
    }
}
