using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface ICartProductRepository
    {
        Task DeleteCartProductAsync(CartProduct item);
        Task AddCartProductAsync(CartProduct item);
    }
}
