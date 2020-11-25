using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductDTO item);
        Task<ProductDTO> ReadAsync(int id);
        IEnumerable<ProductDTO> Read(ProductFilterParams filterParams);
        Task UpdateAsync(ProductDTO item);
        Task DeleteAsync(ProductDTO item);
    }
}
