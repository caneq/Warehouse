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
    public class ClientRequestRepository : IClientRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ClientRequest> _dbSet;
        public ClientRequestRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ClientRequest>();
        }
        public async Task<int> CreateAsync(ClientRequest item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task DeleteAsync(ClientRequest item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientRequest> ReadAsync(Expression<Func<ClientRequest, bool>> predicate)
        {
            var c = await _dbSet.AsNoTracking()
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(predicate);

            return c;
        }

        public IEnumerable<ClientRequest> ReadMany(Func<ClientRequest, bool> predicate)
        {
            return _dbSet.AsNoTracking()
                .Include(c => c.ApplicationUser)
                .Where(predicate).AsEnumerable();
        }

        public async Task UpdateAsync(ClientRequest item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
