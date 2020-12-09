using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IOrderStatusesService
    {
        Task<OrderStatusDTO> GetByStatusStringAsync(string statusString);
        Task CreateAsync(OrderStatusDTO orderStatus);
        Task SetPayed(int orderId, ClaimsPrincipal User);
        Task SetDelivered(int orderId, ClaimsPrincipal User);
    }
}
