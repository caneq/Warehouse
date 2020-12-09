using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IShipmentService
    {
        Task<ShipmentDTO> ReadAsync(int id);
        Task<ShipmentDTO> ReadAsync(ShipmentFilterParams filterParams);
        IEnumerable<ShipmentDTO> ReadMany(ShipmentFilterParams filterParams);
        Task<int> CreateAsync(ShipmentDTO item);
        Task DeleteAsync(ShipmentDTO item);
        Task UpdateAsync(ShipmentDTO item);
    }
}
