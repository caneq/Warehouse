using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    interface IOrderService
    {
        public Task Create(ClaimsPrincipal User, OrderDTO order);
        public IEnumerable<OrderDTO> ReadManyAsync(ClaimsPrincipal User, string userId = null);
        public Task<OrderDTO> ReadAsync(ClaimsPrincipal User, int id);
    }
}
