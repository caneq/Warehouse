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
using Warehouse.ClassLibrary;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class SupplierOrderService : ISupplierOrderService
    {
        private readonly ISupplierOrderRepository _repo;
        private readonly IMapper _mapper;
        public SupplierOrderService(ISupplierOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Create(ClaimsPrincipal User, SupplierOrderDTO order)
        {
            order.UserId = User.GetUserId();
            order.DateTime = DateTime.Now;
            order.ResultPrice = new Price(order.Items.Sum(p => p.Price.Penny));
            await _repo.CreateAsync(_mapper.Map<SupplierOrder>(order));
        }

        public async Task<SupplierOrderDTO> ReadAsync(ClaimsPrincipal User, int id)
        {
            var o = await _repo.ReadAsync(o => o.Id == id);
            return _mapper.Map<SupplierOrderDTO>(o);
        }

        public IEnumerable<SupplierOrderDTO> ReadMany(ClaimsPrincipal User, SupplierOrderFilterParams filterParams = null)
        {
            if (filterParams == null) filterParams = new SupplierOrderFilterParams { };
            var o = _repo.ReadMany(filterParams.GetFuncPredicate());
            return _mapper.Map<IEnumerable<SupplierOrderDTO>>(o);
        }
    }
}
