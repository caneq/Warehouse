using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface ICartService
    {
        Task<CartDTO> ReadAsync(int id);
        Task<CartDTO> ReadAsync(CartFilterParams filterParams);
        IEnumerable<CartDTO> ReadMany(CartFilterParams filterParams);
        Task AddCartProductAsync(CartProductDTO p, ClaimsPrincipal User, string userId = null);
        Task<CartDTO> GetCartAsync(ClaimsPrincipal User, string userId = null);
        Task CreateAsync(CartDTO item);
        Task DeleteAsync(CartDTO item);
        Task UpdateAsync(CartDTO item);
    }
}
