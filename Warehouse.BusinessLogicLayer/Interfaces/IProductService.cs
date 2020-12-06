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
        Task<ProductDTO> ReadAsync(int id);
        Task<ProductDTO> ReadAsync(ProductFilterParams filterParams);
        IEnumerable<ProductDTO> ReadMany(ProductFilterParams filterParams);
        Task<int> CreateAsync(ProductDTO item);
        Task DeleteAsync(ProductDTO item);
        Task UpdateAsync(ProductDTO item);

    }
}
