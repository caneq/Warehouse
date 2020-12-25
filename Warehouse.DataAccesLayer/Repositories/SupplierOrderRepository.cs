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
    public class SupplierOrderRepository : ISupplierOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(SupplierOrder item)
        {
            await _context.SupplierOrders.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task DeleteAsync(SupplierOrder item)
        {
            _context.SupplierOrders.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<SupplierOrder> ReadAsync(Expression<Func<SupplierOrder, bool>> predicate)
        {
            SupplierOrder c = await _context.SupplierOrders.AsNoTracking()
                                .Include(o => o.Supplier)
                                .Include(o => o.Statuses)
                                    .ThenInclude(os => os.SupplierOrderStatus)
                                .OrderByDescending(o => o.DateTime)
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

            c.Statuses = c.Statuses.OrderByDescending(c => c.DateTime).ToList();
            return c;
        }

        public IEnumerable<SupplierOrder> ReadMany(Func<SupplierOrder, bool> predicate)
        {
            var res = _context.SupplierOrders.AsNoTracking()
                    .Include(o => o.Supplier)
                    .Include(o => o.Statuses)
                        .ThenInclude(os => os.SupplierOrderStatus)
                    .OrderByDescending(o => o.DateTime)
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

            res = res.Select(s => {
                s.Statuses = s?.Statuses.OrderByDescending(s => s?.DateTime).ToList();
                return s;
            });
            return res;
        }

        public async Task UpdateAsync(SupplierOrder item)
        {
            var order = await _context.SupplierOrders
                    .Include(o => o.Statuses)
                        .ThenInclude(os => os.SupplierOrderStatus)
                    .OrderByDescending(o => o.DateTime)
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

            order.DateTime = item.DateTime;

            var addedStatuses = item.Statuses.Where(s => !order.Statuses.Any(o => o.SupplierOrderStatus.String == s.SupplierOrderStatus.String));
            var removedStatuses = order.Statuses.Where(s => !item.Statuses.Any(o => o.SupplierOrderStatus.String == s.SupplierOrderStatus.String));

            order.Statuses.AddRange(addedStatuses);
            order.Statuses.RemoveAll(s => removedStatuses.Contains(s));

            order.ResultPrice = item.ResultPrice;
            order.User = item.User;
            order.UserId = item.UserId;

            await _context.SaveChangesAsync();
        }
    }
}
