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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Order>();
        }

        public async Task CreateAsync(Order item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> ReadAsync(Expression<Func<Order, bool>> predicate)
        {
            Order c = await _dbSet.AsNoTracking()
                .Include(o => o.OrderStatuses)
                    .ThenInclude(os => os.OrderStatus)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.ManufactureCountry)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Pictures)
                 .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Unit)
                .FirstOrDefaultAsync(predicate);

            return c;
        }
        public IEnumerable<Order> ReadMany(Func<Order, bool> predicate)
        {
            return _dbSet.AsNoTracking()
                .Include(o => o.OrderStatuses)
                    .ThenInclude(os => os.OrderStatus)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.ManufactureCountry)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Pictures)
                 .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Unit)
                .Where(predicate).AsEnumerable();
        }

        public async Task UpdateAsync(Order item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
