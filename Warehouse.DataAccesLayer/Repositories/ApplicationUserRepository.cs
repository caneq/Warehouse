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
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ApplicationUser> _dbSet;
        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ApplicationUser>();
        }
        public async Task DeleteAsync(ApplicationUser item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> ReadAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            ApplicationUser c = await _dbSet.AsNoTracking()
                            .Include(u => u.Cart)
                            .Include(u => u.ConveyedShipments)
                            .Include(u => u.RepicientShipments)
                            .FirstOrDefaultAsync(predicate);
            return c;
        }

        public IEnumerable<ApplicationUser> ReadMany(Func<ApplicationUser, bool> predicate)
        {
            return _dbSet.AsNoTracking()
                        .Include(u => u.Cart)
                        .Include(u => u.ConveyedShipments)
                        .Include(u => u.RepicientShipments)
                        .Where(predicate).AsEnumerable();
        }

        public async Task UpdateAsync(ApplicationUser item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
