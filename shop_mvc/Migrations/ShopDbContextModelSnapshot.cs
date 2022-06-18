﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop_mvc;

#nullable disable

namespace shop_mvc.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("shop_mvc.Models.BoughtModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bought");
                });

            modelBuilder.Entity("shop_mvc.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("shop_mvc.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 1,
                            Description = "IPhone 11 Opis",
                            Name = "IPhone 11",
                            Price = 699m
                        },
                        new
                        {
                            Id = 2,
                            Count = 1,
                            Description = "Myszka Opis",
                            Name = "Myszka",
                            Price = 699m
                        },
                        new
                        {
                            Id = 3,
                            Count = 1,
                            Description = "Aparat Opis",
                            Name = "Aparat",
                            Price = 699m
                        },
                        new
                        {
                            Id = 4,
                            Count = 1,
                            Description = "PS 4 Opis",
                            Name = "PS 4",
                            Price = 699m
                        });
                });

            modelBuilder.Entity("shop_mvc.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "admin",
                            Email = "admin@admin.com",
                            FirstName = "admin",
                            HashPassword = "AQAAAAEAACcQAAAAEGn3IGsBmSOp78M8hKtd9kLvuvl3U4PjkuR7uOp7iC2U1qsZQhL34+OzILMC4r9NoA==",
                            LastName = "admin",
                            Password = "admin",
                            Phone = "111111111",
                            Role = "Admin",
                            State = "admin",
                            ZipCode = "11-1111"
                        },
                        new
                        {
                            Id = 2,
                            Address = "user",
                            Email = "user@user.com",
                            FirstName = "user",
                            HashPassword = "AQAAAAEAACcQAAAAEL+tndt2YkU94ZbDzJm+dsP3RcddThDpS01b7QXKjUYuHhkuUDbzVTqa+noKHCXK6g==",
                            LastName = "user",
                            Password = "user",
                            Phone = "111111111",
                            Role = "User",
                            State = "user",
                            ZipCode = "11-1111"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
