using System.Collections.Generic;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();

    }
}
