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

        public async Task<int> CreateAsync(Order item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<Order> ReadAsync(Expression<Func<Order, bool>> predicate)
        {
            Order c = await _dbSet.AsNoTracking()
                .Include(o => o.OrderStatuses)
                    .ThenInclude(os => os.OrderStatus)
                .OrderByDescending(o => o.OrderDate)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.ManufactureCountry)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Pictures)
                 .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Unit)
                .Include(o => o.Shipments)
                    .ThenInclude(s => s.Repicient)
                .Include(o => o.Shipments)
                    .ThenInclude(s => s.Conveyed)
                .FirstOrDefaultAsync(predicate);

            c.OrderStatuses = c.OrderStatuses.OrderByDescending(c => c.DateTime).ToList();
            c.Shipments = c.Shipments.OrderByDescending(c => c.DateTime).ToList();
            return c;
        }
        public IEnumerable<Order> ReadMany(Func<Order, bool> predicate)
        {
            var res = _dbSet.AsNoTracking()
                .Include(o => o.OrderStatuses)
                    .ThenInclude(os => os.OrderStatus)
                .OrderByDescending(o => o.OrderDate)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.ManufactureCountry)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Pictures)
                 .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Unit)
                 .Include(o => o.Shipments)
                    .ThenInclude(s => s.Repicient)
                .Include(o => o.Shipments)
                    .ThenInclude(s => s.Conveyed)
                .Where(predicate).AsEnumerable();

            return res.Select(s => {
                s.OrderStatuses = s?.OrderStatuses.OrderByDescending(s => s?.DateTime).ToList();
                return s;
            });
        }

        public async Task UpdateAsync(Order item)
        {
            var order = await _context.Orders
                .Include(o => o.OrderStatuses)
                    .ThenInclude(os => os.OrderStatus)
                .OrderByDescending(o => o.OrderDate)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.ManufactureCountry)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Pictures)
                 .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Unit)
                 .FirstOrDefaultAsync(o => o.Id == item.Id);

            var addedItems = item.Items.Where(s => !order.Items.Any(o => o.Id == s.Id));
            var removedItems = order.Items.Where(s => !item.Items.Any(o => o.Id == s.Id));

            order.Items.AddRange(addedItems);
            order.Items.RemoveAll(s => removedItems.Contains(s));

            order.OrderDate = item.OrderDate;

            var addedStatuses = item.OrderStatuses.Where(s => !order.OrderStatuses.Any(o => o.OrderStatus.OrderStatusString == s.OrderStatus.OrderStatusString));
            var removedStatuses = order.OrderStatuses.Where(s => !item.OrderStatuses.Any(o => o.OrderStatus.OrderStatusString == s.OrderStatus.OrderStatusString));

            order.OrderStatuses.AddRange(addedStatuses);
            order.OrderStatuses.RemoveAll(s => removedStatuses.Contains(s));

            order.TotalPrice = item.TotalPrice;
            order.User = item.User;
            order.UserId = item.UserId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
