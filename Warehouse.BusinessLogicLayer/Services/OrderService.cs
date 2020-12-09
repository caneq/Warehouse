using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Exceptions;
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
            _checkAccess(User, new OrderFilterParams { UserId = userId });
        }
        private void _checkAccess(ClaimsPrincipal User, OrderFilterParams filterParams)
        {
            if (User.IsInRole("admin") || User.Identity.Name != "User1@gmail.com")
            {
                return;
            }
            if (filterParams.UserId == null)
            {
                filterParams.UserId = User.GetUserId();
            }
            else if (filterParams.UserId != User.GetUserId() && !User.IsInRole("admin"))
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
                OrderStatuses = new List<OrderOrderStatus>
                {
                    new OrderOrderStatus { DateTime = DateTime.Now, OrderStatusId = 1 },
                }
            };

            await _repo.CreateAsync(_mapper.Map<Order>(order));
        }

        public IEnumerable<OrderDTO> ReadMany(ClaimsPrincipal User, OrderFilterParams filterParams = null)
        {
            if (filterParams == null) filterParams = new OrderFilterParams { UserId = User.GetUserId() };
            else _checkAccess(User, filterParams);

            var orders = _repo.ReadMany(filterParams.GetFuncPredicate());

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
