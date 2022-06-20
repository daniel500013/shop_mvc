using Microsoft.EntityFrameworkCore;
using shop_mvc.Models;
using System.Configuration;

namespace shop_mvc
{
    public class ShopDbContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<BoughtModel> Bought { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.0.15;Database=ShopDb;Persist Security Info=True;User ID=SA;Password=YHoZ8olz");
        }
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

            modelBuilder.Entity<ProductModel>()
                .HasData(new ProductModel()
                {
                    Id = 1,
                    Name = "IPhone 11",
                    Description = "IPhone 11 Opis",
                    Price = 699
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Myszka",
                    Description = "Myszka Opis",
                    Price = 699
                },
                new ProductModel()
                {
                    Id = 3,
                    Name = "Aparat",
                    Description = "Aparat Opis",
                    Price = 699
                },
                new ProductModel()
                {
                    Id = 4,
                    Name = "PS 4",
                    Description = "PS 4 Opis",
                    Price = 699
                });

            modelBuilder.Entity<UserModel>()
                .HasData(new UserModel()
                {
                    Id = 1,
                    FirstName = "admin",
                    LastName = "admin",
                    Password = "admin",
                    Email = "admin@admin.com",
                    Phone = "111111111",
                    ZipCode = "11-1111",
                    State = "admin",
                    Address = "admin",
                    Role = "Admin",
                    HashPassword = "AQAAAAEAACcQAAAAEGn3IGsBmSOp78M8hKtd9kLvuvl3U4PjkuR7uOp7iC2U1qsZQhL34+OzILMC4r9NoA=="
                },
                new UserModel()
                {
                    Id = 2,
                    FirstName = "user",
                    LastName = "user",
                    Password = "user",
                    Email = "user@user.com",
                    Phone = "111111111",
                    ZipCode = "11-1111",
                    State = "user",
                    Address = "user",
                    Role = "User",
                    HashPassword = "AQAAAAEAACcQAAAAEL+tndt2YkU94ZbDzJm+dsP3RcddThDpS01b7QXKjUYuHhkuUDbzVTqa+noKHCXK6g=="
                });
        }
    }
}
