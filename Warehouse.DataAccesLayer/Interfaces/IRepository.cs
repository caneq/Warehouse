using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DataAccesLayer.Interfaces
{
    interface IRepository<T> where T : class
    {
        void CreateAsync(T item);
        void UpdateAsync(T item);
        Task<T> ReadAsync(int id);
        IEnumerable<T> Read(Func<T, Boolean> predicate);
        IEnumerable<T> ReadWithInclude(Func<T, Boolean> predicate, params Expression<Func<T, object>>[] includeProperties);
        void DeleteAsync(T item);
    }
}
