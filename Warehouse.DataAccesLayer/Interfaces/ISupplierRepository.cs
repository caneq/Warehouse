using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> ReadAsync(Expression<Func<Supplier, bool>> predicate);
        IEnumerable<Supplier> ReadMany(Func<Supplier, Boolean> predicate);
        Task UpdateAsync(Supplier item);
        Task DeleteAsync(Supplier item);
    }
}
