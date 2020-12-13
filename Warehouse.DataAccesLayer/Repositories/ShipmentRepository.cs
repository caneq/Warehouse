using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Data;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Shipment> _dbSet;
        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Shipment>();
        }

        public async Task<int> CreateAsync(Shipment item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task DeleteAsync(Shipment item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Shipment> ReadAsync(Expression<Func<Shipment, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
                    .Include(p => p.Order)
                        .ThenInclude(o => o.Items)
                            .ThenInclude(i => i.Product)
                                .ThenInclude(p => p.Unit)
                    .Include(p => p.Repicient)
                    .Include(p => p.Conveyed)
                    .FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<Shipment> ReadMany(Func<Shipment, bool> predicate)
        {
            return _dbSet.AsNoTracking().AsNoTracking()
                    .Include(p => p.Order)
                        .ThenInclude(o => o.Items)
                            .ThenInclude(i => i.Product)
                                .ThenInclude(p => p.Unit)
                    .Include(p => p.Repicient)
                    .Include(p => p.Conveyed)
                    .OrderByDescending(s => s.DateTime)
                .Where(predicate).AsEnumerable();
        }

        public async Task UpdateAsync(Shipment item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
