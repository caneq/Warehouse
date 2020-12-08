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
        private readonly IRepository<OrderStatus> _statusesRepo;
        public OrderService(IOrderRepository repo, IRepository<OrderStatus> statusesRepo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _statusesRepo = statusesRepo;
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
            //var orders = _repo.ReadMany(p => true);

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> ReadAsync(ClaimsPrincipal User, int id)
        {
            var o = await _repo.ReadAsync(o => o.Id == id);
            _checkAccess(User, o.UserId);
            return _mapper.Map<OrderDTO>(o);
        }

        public async Task SetPayed(int orderId, ClaimsPrincipal User)
        {
            var order = await _repo.ReadAsync(o => o.Id == orderId);
            if (order == null) throw new NotFoundException();
            _checkAccess(User, order.UserId);
            var payedStatus = await _statusesRepo.ReadAsync(s => s.OrderStatusString == "Оплачен");
            if (payedStatus == null)
            {
                await _statusesRepo.CreateAsync(new OrderStatus { OrderStatusString = "Оплачен" });
                payedStatus = await _statusesRepo.ReadAsync(s => s.OrderStatusString == "Оплачен");
            }
            var WaitingDeliveryStatus = await _statusesRepo.ReadAsync(s => s.OrderStatusString == "Ожидание доставки");

            order.OrderStatuses.Add(new OrderOrderStatus
            {
                OrderId = order.Id,
                OrderStatus = payedStatus,
                DateTime = DateTime.Now,
            });
            order.OrderStatuses.Add(new OrderOrderStatus
            {
                OrderId = order.Id,
                OrderStatus = WaitingDeliveryStatus,
                DateTime = DateTime.Now,
            });
            await _repo.UpdateAsync(order);
        }
    }
}
