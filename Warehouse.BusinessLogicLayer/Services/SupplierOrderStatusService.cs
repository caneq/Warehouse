using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Exceptions;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class SupplierOrderStatusService : ISupplierOrderStatusService
    {
        private readonly IRepository<SupplierOrderStatus> _repo;
        private readonly ISupplierOrderRepository _supplierOrderRepository;
        private readonly IMapper _mapper;
        public SupplierOrderStatusService(IRepository<SupplierOrderStatus> repo, ISupplierOrderRepository supplierOrderRepository, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _supplierOrderRepository = supplierOrderRepository;
        }
        public async Task CreateAsync(SupplierOrderStatusDTO orderStatus)
        {
            await _repo.CreateAsync(_mapper.Map<SupplierOrderStatus>(orderStatus));
        }

        public async Task<SupplierOrderStatusDTO> GetByStatusStringAsync(string statusString)
        {
            var res = await _repo.ReadAsync(s => s.String == statusString);
            return _mapper.Map<SupplierOrderStatusDTO>(res);
        }

        public async Task SetByStatusString(int orderId, string statusString, ClaimsPrincipal User)
        {
            var order = await _supplierOrderRepository.ReadAsync(o => o.Id == orderId);
            if (order == null) throw new NotFoundException();

            var status = await _repo.ReadAsync(s => s.String == statusString);
            if (status == null)
            {
                await _repo.CreateAsync(new SupplierOrderStatus { String = statusString });
                status = await _repo.ReadAsync(s => s.String == statusString);
            }
            order.Statuses.Add(new SupplierOrderStatusSupplierOrder
            {
                SupplierOrderId = order.Id,
                SupplierOrderStatus = status,
                DateTime = DateTime.Now,
            });

            await _supplierOrderRepository.UpdateAsync(order);
        }
    }
}
