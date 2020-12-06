using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateAsync(Product item);
        Task<Product> ReadAsync(Expression<Func<Product, bool>> predicate);
        IEnumerable<Product> ReadMany(Func<Product, Boolean> predicate);
        Task UpdateAsync(Product item);
        Task DeleteAsync(Product item);
    }
}
