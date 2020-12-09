using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;
using System.Security.Claims;
using Warehouse.BusinessLogicLayer.Exceptions;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class OrderStatusesService : IOrderStatusesService
    {
        private readonly IRepository<OrderStatus> _repo;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderStatusesService(IRepository<OrderStatus> repo, IOrderRepository orderRepository, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task CreateAsync(OrderStatusDTO orderStatus)
        {
            await _repo.CreateAsync(_mapper.Map<OrderStatus>(orderStatus));
        }

        public async Task<OrderStatusDTO> GetByStatusStringAsync(string statusString)
        {
            var res = await _repo.ReadAsync(s => s.OrderStatusString == statusString);
            return _mapper.Map<OrderStatusDTO>(res);
        }

        private async Task _addStatus(Order o, string statusString)
        {
            var status = await _repo.ReadAsync(s => s.OrderStatusString == statusString);
            if (status == null)
            {
                await _repo.CreateAsync(new OrderStatus { OrderStatusString = statusString });
                status = await _repo.ReadAsync(s => s.OrderStatusString == statusString);
            }
            o.OrderStatuses.Add(new OrderOrderStatus
            {
                OrderId = o.Id,
                OrderStatus = status,
                DateTime = DateTime.Now,
            });
        }

        public async Task SetDelivered(int orderId, ClaimsPrincipal User)
        {
            var order = await _orderRepository.ReadAsync(o => o.Id == orderId);
            if (order == null) throw new NotFoundException();

            await _addStatus(order, "Доставлен");
            await _addStatus(order, "Завершен");
            
            await _orderRepository.UpdateAsync(order);
        }

        public async Task SetPayed(int orderId, ClaimsPrincipal User)
        {
            var order = await _orderRepository.ReadAsync(o => o.Id == orderId);
            if (order == null) throw new NotFoundException();

            await _addStatus(order, "Оплачен");
            await _addStatus(order, "Ожидание доставки");

            await _orderRepository.UpdateAsync(order);
        }

        public async Task SetByStatusString(int orderId, string status, ClaimsPrincipal User)
        {
            var order = await _orderRepository.ReadAsync(o => o.Id == orderId);
            if (order == null) throw new NotFoundException();

            await _addStatus(order, status);

            await _orderRepository.UpdateAsync(order);
        }
    }
}
