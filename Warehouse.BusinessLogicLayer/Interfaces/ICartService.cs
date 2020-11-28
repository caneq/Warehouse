using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces.Generic;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface ICartService : IGenericService<CartDTO>
    {

        Task<CartDTO> ReadWithIncludeAsync(int id);
        IEnumerable<CartDTO> ReadMany(CartFilterParams filterParams);
        IEnumerable<CartDTO> ReadManyWithInclude(CartFilterParams filterParams);

    }
}
