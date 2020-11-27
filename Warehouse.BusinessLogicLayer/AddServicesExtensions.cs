using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Services;
using Warehouse.DataAccessLayer;

namespace Warehouse.BusinessLogicLayer
{
    public static class AddServicesExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(AddServicesExtensions));
            services.AddDataRepositories(connectionString);
        }
    }
}
