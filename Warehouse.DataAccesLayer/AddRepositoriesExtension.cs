using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Warehouse.DataAccessLayer.Data;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;
using Warehouse.DataAccessLayer.Repositories;

namespace Warehouse.DataAccessLayer
{
    public static class AddRepositoriesExtension
    {
        public static void AddDataRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
            services.AddScoped<IRepository<Cart>, Repository<Cart>>();
            services.AddScoped<IRepository<Country>, Repository<Country>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<OrderStatus>, Repository<OrderStatus>>();
            services.AddScoped<IRepository<Unit>, Repository<Unit>>();


        }
    }
}
