using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer
{
    public class BusinessLogicLayerMappingProfile : Profile
    {
        public BusinessLogicLayerMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<CartProduct, CartProductDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();
            CreateMap<OrderOrderStatus, OrderOrderStatusDTO>().ReverseMap();
            CreateMap<Url, UrlDTO>().ReverseMap();
            CreateMap<Shipment, ShipmentDTO>().ReverseMap();
            CreateMap<ClientRequest, ClientRequestDTO>().ReverseMap();
            CreateMap<ClientRequestMessage, ClientRequestMessageDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<SupplierOrder, SupplierOrderDTO>().ReverseMap();
            CreateMap<SupplierOrderItem, SupplierOrderItemDTO>().ReverseMap();
            CreateMap<SupplierOrderStatus, SupplierOrderStatusDTO>().ReverseMap();
            CreateMap<SupplierOrderSupplierOrderStatus, SupplierOrderSupplierOrderStatusDTO>().ReverseMap();

        }
    }
}
