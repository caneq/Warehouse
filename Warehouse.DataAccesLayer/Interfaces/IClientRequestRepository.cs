using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface IClientRequestRepository
    {
        Task<int> CreateAsync(ClientRequest item);
        Task<ClientRequest> ReadAsync(Expression<Func<ClientRequest, bool>> predicate);
        IEnumerable<ClientRequest> ReadMany(Func<ClientRequest, Boolean> predicate);
        Task UpdateAsync(ClientRequest item);
        Task DeleteAsync(ClientRequest item);
    }
}
