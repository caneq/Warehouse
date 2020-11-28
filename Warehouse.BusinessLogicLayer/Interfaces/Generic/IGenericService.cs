using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces.Generic
{
    public interface IGenericService<T> where T : class
    {
        Task CreateAsync(T item);
        Task<T> ReadAsync(int id);

        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
