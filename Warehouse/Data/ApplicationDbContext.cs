using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Url> Uris { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Country>().HasData(
                new Country[]
                {
                    new Country{ CountryId = 1, Name = "Китай"},
                    new Country{ CountryId = 2, Name = "Беларусь"},
                    new Country{ CountryId = 3, Name = "Россия"},
                }
            );

            builder.Entity<Unit>().HasData(
                new Unit[]
                {
                    new Unit  { UnitId = 1, UnitString = "шт" },
                    new Unit  { UnitId = 2, UnitString = "л." },
                    new Unit  { UnitId = 3, UnitString = "кг" },
                }
           );


            builder.Entity<OrderStatus>().HasData(
                new OrderStatus[]
                {
                    new OrderStatus  { OrderStatusId = 1, OrderStatusString = "Ожидание оплаты" },
                    new OrderStatus  { OrderStatusId = 2, OrderStatusString = "Ожидание доставки" },
                    new OrderStatus  { OrderStatusId = 3, OrderStatusString = "Завершен" },
                }
           );

            builder.Entity<Url>().HasData(
                new Url[]
                {
                    new Url  { UrlId = 1,ProductId = 1 , UrlString = "https://avatars.mds.yandex.net/get-mpic/1365202/img_id7828880432754619849.png/orig" },
                    new Url  { UrlId = 2,ProductId = 1, UrlString = "https://avatars.mds.yandex.net/get-mpic/1056698/img_id5528712325692372091.png/orig" },
                    new Url  { UrlId = 3,ProductId = 2, UrlString = "https://avatars.mds.yandex.net/get-mpic/1332324/img_id4552048093897868354.jpeg/orig" },
                    new Url  { UrlId = 4,ProductId = 3, UrlString = "https://avatars.mds.yandex.net/get-mpic/1614201/img_id580048981333677263.jpeg/orig" },
                }
           );

            builder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product { ProductId = 1, Name = "Материнская плата ASRock X370 Pro4", Description = "",
                        CountInStock = 10, Price = 300.0f, ShelfLife = int.MaxValue, Weight = 0.2f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { ProductId = 2, Name = "Процессор AMD Ryzen 7 2700", Description = "",
                        CountInStock = 14, Price = 210.0f, ShelfLife = int.MaxValue, Weight = 0.4f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { ProductId = 3, Name = "Твердотельный накопитель Samsung 970 EVO Plus 500 GB", Description = "",
                        CountInStock = 30, Price = 270.0f, ShelfLife = int.MaxValue, Weight = 0.3f,
                        UnitId = 1, ManufactureCountryId = 1 },
                }
           );
        }
    }
}
