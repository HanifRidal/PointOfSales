using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSales.Models.Domain
{
    public class Produk
    {
        [Key]
        public Guid ProdukId { get; set; } 
        [StringLength(50)]
        public string? Name { get; set; } //null-forgiving op.
        [StringLength(1000)]
        public string Description { get; set; }
        public double Price { get; set; }

        public Guid CategoryId { get; set; }

        //[ForeignKey("Category")]
        public Category Category { get; set; }


    }
}
