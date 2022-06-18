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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(x => x.Email)
                .IsRequired();
            
            modelBuilder.Entity<ProductModel>()
                .Property(x => x.Name)
                .IsRequired();
        }

        public DbSet<shop_mvc.Models.RoleBase>? RoleBase { get; set; }
    }
}
