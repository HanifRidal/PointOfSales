using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PointOfSales.Models.Domain;
using System.Reflection.Metadata;

namespace PointOfSales.Data
{
    public class AppDbContext : DbContext
    {
        //CONTRUCTOR
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(i => i.Product)
                .HasForeignKey(f => f.CategoryId);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Produk>().ToTable(nameof(Produk));
            //modelBuilder.Entity<Category>().ToTable(nameof(Category));
        }

    }
}
