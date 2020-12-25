using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;
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
            CreateMap<UrlViewModel, UrlDTO>().ReverseMap();
            CreateMap<ShipmentViewModel, ShipmentDTO>().ReverseMap();
            CreateMap<ClientRequestViewModel, ClientRequestDTO>().ReverseMap();
            CreateMap<ClientRequestMessageViewModel, ClientRequestMessageDTO>().ReverseMap();
            CreateMap<ClientRequestFilterViewModel, ClientRequestFilterParams>().ReverseMap();
            CreateMap<SupplierViewModel, SupplierDTO>().ReverseMap();
            CreateMap<SupplierOrderViewModel, SupplierOrderDTO>().ReverseMap();
            CreateMap<SupplierOrderItemViewModel, SupplierOrderItemDTO>().ReverseMap();
            CreateMap<SupplierOrderStatusViewModel, SupplierOrderStatusDTO>().ReverseMap();
            CreateMap<SupplierOrderSupplierOrderStatusViewModel, SupplierOrderSupplierOrderStatusDTO>().ReverseMap();
            CreateMap<ProductFilterViewModel, ProductFilterParams>().ReverseMap();

        }
    }
}
