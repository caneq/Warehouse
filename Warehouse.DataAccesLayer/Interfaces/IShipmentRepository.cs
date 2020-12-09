using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Interfaces
{
    public interface IShipmentRepository
    {
        Task<int> CreateAsync(Shipment item);
        Task<Shipment> ReadAsync(Expression<Func<Shipment, bool>> predicate);
        IEnumerable<Shipment> ReadMany(Func<Shipment, Boolean> predicate);
        Task UpdateAsync(Shipment item);
        Task DeleteAsync(Shipment item);
    }
}
