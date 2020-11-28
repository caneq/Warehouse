using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : IDataModel
    {
        Task CreateAsync(T item);
        Task<T> ReadAsync(int id);
        IEnumerable<T> ReadMany(Func<T, Boolean> predicate);
        IEnumerable<T> ReadManyWithInclude(Func<T, Boolean> predicate);
        Task<T> ReadFirstWithIncludeAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
