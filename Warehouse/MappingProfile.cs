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
            CreateMap<CartProductViewModel, CartProductDTO>().ReverseMap();
            CreateMap<CountryViewModel, CountryDTO>().ReverseMap();
            CreateMap<OrderViewModel, OrderDTO>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemDTO>().ReverseMap();
            CreateMap<OrderStatusViewModel, OrderStatusDTO>().ReverseMap();
            CreateMap<OrderOrderStatusViewModel, OrderOrderStatusDTO>().ReverseMap();
            //CreateMap<PriceViewModel, PriceDTO>().ReverseMap();
            CreateMap<UrlViewModel, UrlDTO>().ReverseMap();
            CreateMap<ShipmentViewModel, ShipmentDTO>().ReverseMap();
            CreateMap<ClientRequestViewModel, ClientRequestDTO>().ReverseMap();

            //TEMP
            //view - data
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Unit, UnitViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusViewModel>().ReverseMap();
            //CreateMap<Price, PriceViewModel>().ReverseMap();
            CreateMap<Url, UrlViewModel>().ReverseMap();
        }
    }
}
