using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductDTO item);
        Task<ProductDTO> ReadAsync(int id);
        IEnumerable<ProductDTO> Read(Func<ProductDTO, Boolean> predicate);
        IEnumerable<ProductDTO> ReadWithInclude(Func<ProductDTO, Boolean> predicate, params Expression<Func<ProductDTO, object>>[] includeProperties);
        Task UpdateAsync(ProductDTO item);
        Task DeleteAsync(ProductDTO item);
    }
}
