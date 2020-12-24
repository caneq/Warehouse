using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface ISupplierOrderRepository
    {
        Task<int> CreateAsync(SupplierOrder item);
        Task<SupplierOrder> ReadAsync(Expression<Func<SupplierOrder, bool>> predicate);
        IEnumerable<SupplierOrder> ReadMany(Func<SupplierOrder, Boolean> predicate);
        Task UpdateAsync(SupplierOrder item);
        Task DeleteAsync(SupplierOrder item);
    }
}
