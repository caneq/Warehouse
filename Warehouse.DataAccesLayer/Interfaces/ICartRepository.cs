using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface ICartRepository
    {
        Task<int> CreateAsync(Cart item);
        Task<Cart> ReadAsync(Expression<Func<Cart, bool>> predicate);
        IEnumerable<Cart> ReadMany(Func<Cart, Boolean> predicate);
        Task UpdateAsync(Cart item);
        Task DeleteAsync(Cart item);
    }
}
