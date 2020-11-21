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
        Task<T> ReadAsync(int id);
        IEnumerable<T> Read(Func<T, Boolean> predicate);
        IEnumerable<T> ReadWithInclude(Func<T, Boolean> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
