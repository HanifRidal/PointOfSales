using Microsoft.EntityFrameworkCore;
using PointOfSales.Models.Domain;

namespace PointOfSales.Data
{
    public class AppDbContext : DbContext
    {
        //CONTRUCTOR
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Produk> Produks { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Produk>()
        //    //    .HasOne(p => p.Category)
        //    //    .WithMany()
        //    //    .HasForeignKey(p => p.CategoryId);
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Produk>().ToTable(nameof(Produk));
        //    modelBuilder.Entity<Category>().ToTable(nameof(Category));
        //}

    }
}
