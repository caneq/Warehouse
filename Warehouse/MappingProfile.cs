using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.DataAccessLayer.Models;
using Warehouse.PresentationLayer.ViewModel;

namespace Warehouse
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Console.WriteLine("zdarova");
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<Func<Product, bool>, Func<ProductDTO, bool>>().ReverseMap();
            CreateMap<Func<ProductViewModel, bool>, Func<ProductDTO, bool>>().ReverseMap();
        }
    }
}
