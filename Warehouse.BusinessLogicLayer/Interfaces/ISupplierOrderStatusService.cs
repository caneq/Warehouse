using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface ISupplierOrderStatusService
    {
        Task<SupplierOrderStatusDTO> GetByStatusStringAsync(string statusString);
        Task CreateAsync(SupplierOrderStatusDTO orderStatus);
        Task SetByStatusString(int orderId, string status, ClaimsPrincipal User);
    }
}
