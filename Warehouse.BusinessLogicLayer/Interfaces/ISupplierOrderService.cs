using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface ISupplierOrderService
    {
        public Task Create(ClaimsPrincipal User, SupplierOrderDTO order);
        public IEnumerable<SupplierOrderDTO> ReadMany(ClaimsPrincipal User, SupplierOrderFilterParams filterParams = null);
        public Task<SupplierOrderDTO> ReadAsync(ClaimsPrincipal User, int id);
    }
}
