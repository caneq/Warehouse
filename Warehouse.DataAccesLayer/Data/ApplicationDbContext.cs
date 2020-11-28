using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
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
                    new Country{ CountryId = 4, Name = "Индия"},
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
                    new Url  { UrlId = 5,ProductId = 4, UrlString = "https://avatars.mds.yandex.net/get-mpic/1909520/img_id8306103419771387034.jpeg/orig" },
                    new Url  { UrlId = 6,ProductId = 4, UrlString = "https://avatars.mds.yandex.net/get-mpic/1866164/img_id5608834248530713529.jpeg/orig" },
                    new Url  { UrlId = 7,ProductId = 5, UrlString = "https://avatars.mds.yandex.net/get-mpic/1863454/img_id2637791473799097205.jpeg/orig" },
                    new Url  { UrlId = 8,ProductId = 5, UrlString = "https://avatars.mds.yandex.net/get-mpic/1927699/img_id4100362096269675431.png/orig" },
                }
           );

            builder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product { ProductId = 1, Name = "Материнская плата ASRock X370 Pro4", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 10, Price = 300.0f, ShelfLife = int.MaxValue, Weight = 0.2f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { ProductId = 2, Name = "Процессор AMD Ryzen 7 2700", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 14, Price = 210.0f, ShelfLife = int.MaxValue, Weight = 0.4f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { ProductId = 3, Name = "Твердотельный накопитель Samsung 970 EVO Plus 500 GB", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 30, Price = 270.0f, ShelfLife = int.MaxValue, Weight = 0.3f,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { ProductId = 4, Name = "Стиральная машина Beko RSGE 685P2 BSW", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 23, Price = 646.0f, ShelfLife = int.MaxValue, Weight = 50,
                        UnitId = 1, ManufactureCountryId = 1 },
                    new Product { ProductId = 5, Name = "Смартфон Apple iPhone 12 Pro 128GB", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CountInStock = 6, Price = 3960f, ShelfLife = int.MaxValue, Weight = 0.187f,
                        UnitId = 1, ManufactureCountryId = 1 },
                }
           );

            builder.Entity<Cart>().HasData(
                new Cart[]
                {
                    new Cart{ CartId = 1, ApplicationUserId = "4214922f-e90b-4100-9481-d70c81f5f843" },
                }
            );
            builder.Entity<CartProduct>().HasData(
                new CartProduct[]
                {
                    new CartProduct{ CartProductId = 1, CartId = 1, ProductId = 2},
                    new CartProduct{ CartProductId = 2, CartId = 1, ProductId = 3},
                    new CartProduct{ CartProductId = 3, CartId = 1, ProductId = 5},
                }
            );
        }
    }
}
