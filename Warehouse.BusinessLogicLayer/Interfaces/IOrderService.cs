using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        public Task Create(ClaimsPrincipal User, IEnumerable<ProductDTO> products, string userId = null);
        public IEnumerable<OrderDTO> ReadMany(ClaimsPrincipal User, OrderFilterParams filterParams = null);
        public Task<OrderDTO> ReadAsync(ClaimsPrincipal User, int id);
    }
}
