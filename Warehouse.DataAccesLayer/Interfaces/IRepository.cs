using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T item);
        Task<T> ReadAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> ReadMany(Func<T, Boolean> predicate);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
