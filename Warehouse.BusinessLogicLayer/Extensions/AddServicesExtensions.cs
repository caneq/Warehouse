using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Services;
using Warehouse.DataAccessLayer;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Extensions
{
    public static class AddServicesExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IOrderService, OrderService>();

            //services.AddScoped<IGenericService<CountryDTO>, GenericService<CountryDTO, Country>>();
            //services.AddScoped<IGenericService<OrderStatus>, GenericService<OrderStatus, OrderStatus>>();
            //services.AddScoped<IGenericService<UnitDTO>, GenericService<UnitDTO, Unit>>();

            services.AddAutoMapper(typeof(AddServicesExtensions));
            services.AddDataRepositories(connectionString);
        }
    }
}
