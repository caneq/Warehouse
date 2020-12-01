using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Extensions;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.DataAccessLayer.Data;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        private void _checkAccess(ClaimsPrincipal User, string userId)
        {
            if (userId != User.GetUserId() && !User.IsInRole("admin"))
            {
                throw new UnauthorizedAccessException();
            }
        }
        public async Task Create(ClaimsPrincipal User, IEnumerable<ProductDTO> products, string userId = null)
        {
            userId = userId ?? User.GetUserId();
            _checkAccess(User, userId);

            Order order = new Order
            {
                UserId = userId,
                Items = products.Select(p => new OrderItem { Price = p.Price, ProductId = p.Id }).ToList(),
                OrderDate = DateTime.Now,
                TotalPrice = new ClassLibrary.Price(products.Sum(p => p.Price.Penny)),
                OrderStatus = new OrderStatus { OrderStatusString = "Ожидание оплаты" },
            };

            await _repo.CreateAsync(_mapper.Map<Order>(order));
        }

        public IEnumerable<OrderDTO> ReadMany(ClaimsPrincipal User, string userId = null)
        {
            if(userId == null)
            {
                userId = User.GetUserId();
            }
            else
            {
                _checkAccess(User, userId);
            }
            var orders = _repo.ReadMany(o => o.UserId == userId);

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> ReadAsync(ClaimsPrincipal User, int id)
        {
            var o = await _repo.ReadAsync(o => o.Id == id);
            _checkAccess(User, o.UserId);
            return _mapper.Map<OrderDTO>(o);
        }

    }
}
