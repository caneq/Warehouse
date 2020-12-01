using AutoMapper;
using System;
using System.Collections.Generic;
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
        public async Task Create(ClaimsPrincipal User, OrderDTO order)
        {
            _checkAccess(User, order.UserId);
            await _repo.CreateAsync(_mapper.Map<Order>(order));
        }

        public IEnumerable<OrderDTO> ReadManyAsync(ClaimsPrincipal User, string userId = null)
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
