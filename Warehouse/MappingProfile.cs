using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.DataAccessLayer.Models;
using Warehouse.ViewModels;

namespace Warehouse
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //view - bussiness
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<UnitViewModel, UnitDTO>().ReverseMap();
            CreateMap<ApplicationUserViewModel, ApplicationUserDTO>().ReverseMap();
            CreateMap<CartViewModel, CartDTO>().ReverseMap();
            CreateMap<CountryViewModel, CountryDTO>().ReverseMap();
            CreateMap<OrderViewModel, OrderDTO>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemDTO>().ReverseMap();
            CreateMap<OrderStatusViewModel, OrderStatusDTO>().ReverseMap();
            //CreateMap<PriceViewModel, PriceDTO>().ReverseMap();
            CreateMap<UrlViewModel, UrlDTO>().ReverseMap();

            //bussiness - data
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();
            CreateMap<Price, PriceDTO>().ReverseMap();
            CreateMap<Url, UrlDTO>().ReverseMap();
        }
    }
}
