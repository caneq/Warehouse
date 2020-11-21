using System;
using System.Collections.Generic;
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
        void DeleteAsync(T item);
    }
}
