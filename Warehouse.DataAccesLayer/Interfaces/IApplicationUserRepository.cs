using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface IApplicationUserRepository
    {

        Task<ApplicationUser> ReadAsync(Expression<Func<ApplicationUser, bool>> predicate);
        IEnumerable<ApplicationUser> ReadMany(Func<ApplicationUser, Boolean> predicate);
        Task UpdateAsync(ApplicationUser item);
        Task DeleteAsync(ApplicationUser item);
    }
}
