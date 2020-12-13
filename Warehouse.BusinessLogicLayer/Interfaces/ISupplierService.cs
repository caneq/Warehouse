using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierDTO> ReadAsync(int id);
        IEnumerable<SupplierDTO> ReadAll();
        Task CreateAsync(SupplierDTO item);
        Task DeleteAsync(SupplierDTO item);
        Task UpdateAsync(SupplierDTO item);
    }
}
