using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateAsync(Order item);
        Task<Order> ReadAsync(Expression<Func<Order, bool>> predicate);
        IEnumerable<Order> ReadMany(Func<Order, Boolean> predicate);
        Task UpdateAsync(Order item);
        Task DeleteAsync(Order item);
    }
}
