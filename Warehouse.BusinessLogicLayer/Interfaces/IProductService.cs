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
        Task<ProductDTO> ReadWithIncludeAsync(int id);
        IEnumerable<ProductDTO> ReadMany(ProductFilterParams filterParams);
        IEnumerable<ProductDTO> ReadManyWithInclude(ProductFilterParams filterParams);
        Task UpdateAsync(ProductDTO item);
        Task DeleteAsync(ProductDTO item);
    }
}
