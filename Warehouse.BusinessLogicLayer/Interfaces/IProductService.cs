using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces.Generic;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IProductService : IGenericService<ProductDTO>
    {

        Task<ProductDTO> ReadWithIncludeAsync(int id);
        IEnumerable<ProductDTO> ReadMany(ProductFilterParams filterParams);
        IEnumerable<ProductDTO> ReadManyWithInclude(ProductFilterParams filterParams);

    }
}
