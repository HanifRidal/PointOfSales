using System.ComponentModel.DataAnnotations;

namespace PointOfSales.Models.Domain
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

    }
}
