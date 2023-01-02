using Microsoft.EntityFrameworkCore;

namespace Api_HPlusSport.Models
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext>options):base(options)
        {

        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(m => m.Products)
                .WithOne(o => o.Category)
                .HasForeignKey(f => f.CategoryId);
            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



    }

   
    


}
