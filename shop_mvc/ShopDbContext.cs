using Microsoft.EntityFrameworkCore;
using shop_mvc.Models;
namespace shop_mvc
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<BoughtModel> Bought { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(x => x.Email)
                .IsRequired();
            
            modelBuilder.Entity<ProductModel>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<OrderModel>()
                .Property(x => x.ProductID)
                .IsRequired();

            modelBuilder.Entity<OrderModel>()
                .Property(x => x.UserID)
                .IsRequired();

            modelBuilder.Entity<BoughtModel>();
        }
    }
}
