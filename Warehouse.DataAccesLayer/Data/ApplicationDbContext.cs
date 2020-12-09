using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.ClassLibrary;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Product>()
                .Property(p => p.Price)
                .HasConversion(p => p.Penny, p => new Price(p));

            builder
                .Entity<Order>()
                .Property(p => p.TotalPrice)
                .HasConversion(p => p.Penny, p => new Price(p));

            builder
                .Entity<OrderItem>()
                .Property(p => p.Price)
                .HasConversion(p => p.Penny, p => new Price(p));

            builder.Entity<Country>().HasData(
                new Country[]
                {
                    new Country{ Id = 1, Name = "Китай"},
                    new Country{ Id = 2, Name = "Беларусь"},
                    new Country{ Id = 3, Name = "Россия"},
                    new Country{ Id = 4, Name = "Индия"},
                }
            );

            builder.Entity<Unit>().HasData(
                new Unit[]
                {
                    new Unit  { Id = 1, UnitString = "шт" },
                    new Unit  { Id = 2, UnitString = "л." },
                    new Unit  { Id = 3, UnitString = "кг" },
                }
           );


            builder.Entity<OrderStatus>().HasData(
                new OrderStatus[]
                {
                    new OrderStatus  { Id = 1, OrderStatusString = "Ожидание оплаты" },
                    new OrderStatus  { Id = 2, OrderStatusString = "Ожидание доставки" },
                    new OrderStatus  { Id = 3, OrderStatusString = "Завершен" },
                    new OrderStatus  { Id = 4, OrderStatusString = "Неудачная попытка доставки" },
                }
           );

            builder.Entity<Url>().HasData(
                new Url[]
                {
                    new Url  { Id = 1,ProductId = 1 , UrlString = "https://avatars.mds.yandex.net/get-mpic/1365202/img_id7828880432754619849.png/orig" },
                    new Url  { Id = 2,ProductId = 1, UrlString = "https://avatars.mds.yandex.net/get-mpic/1056698/img_id5528712325692372091.png/orig" },
                    new Url  { Id = 3,ProductId = 2, UrlString = "https://avatars.mds.yandex.net/get-mpic/1332324/img_id4552048093897868354.jpeg/orig" },
                    new Url  { Id = 4,ProductId = 3, UrlString = "https://avatars.mds.yandex.net/get-mpic/1614201/img_id580048981333677263.jpeg/orig" },
                    new Url  { Id = 5,ProductId = 4, UrlString = "https://avatars.mds.yandex.net/get-mpic/1909520/img_id8306103419771387034.jpeg/orig" },
                    new Url  { Id = 6,ProductId = 4, UrlString = "https://avatars.mds.yandex.net/get-mpic/1866164/img_id5608834248530713529.jpeg/orig" },
                    new Url  { Id = 7,ProductId = 5, UrlString = "https://avatars.mds.yandex.net/get-mpic/1863454/img_id2637791473799097205.jpeg/orig" },
                    new Url  { Id = 8,ProductId = 5, UrlString = "https://avatars.mds.yandex.net/get-mpic/1927699/img_id4100362096269675431.png/orig" },
                }
           );

            builder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product { Id = 1, Name = "Материнская плата ASRock X370 Pro4", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 10, Price = new Price(30099), ShelfLife = int.MaxValue, Weight = 0.2f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { Id = 2, Name = "Процессор AMD Ryzen 7 2700", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 14, Price = new Price(2109), ShelfLife = int.MaxValue, Weight = 0.4f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { Id = 3, Name = "Твердотельный накопитель Samsung 970 EVO Plus 500 GB", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 30, Price = new Price(27000), ShelfLife = int.MaxValue, Weight = 0.3f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { Id = 4, Name = "Стиральная машина Beko RSGE 685P2 BSW", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 23, Price = new Price(64600), ShelfLife = int.MaxValue, Weight = 50,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { Id = 5, Name = "Смартфон Apple iPhone 12 Pro 128GB", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 6, Price = new Price(3960), ShelfLife = int.MaxValue, Weight = 0.187f,
                        UnitId = 1, ManufactureCountryId = 1 },
                }
           );
        }
    }
}
