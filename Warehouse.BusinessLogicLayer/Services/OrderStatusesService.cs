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

namespace Warehouse.BusinessLogicLayer.Services
{
    public class OrderStatusesService : IOrderStatusesService
    {
        private readonly IRepository<OrderStatus> _repo;
        private readonly IMapper _mapper;
        public OrderStatusesService(IRepository<OrderStatus> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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
    }
}
