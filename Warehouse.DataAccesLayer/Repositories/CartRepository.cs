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
    class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Cart> _dbSet;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Cart>();
        }

        public async Task CreateAsync(Cart item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> ReadAsync(Expression<Func<Cart, bool>> predicate)
        {
            Cart c = await _dbSet.AsNoTracking()
                .Include(c => c.CartProducts)
                    .ThenInclude(c => c.Product)
                        .ThenInclude(p => p.Pictures)
                .Include(c => c.CartProducts)
                    .ThenInclude(c => c.Product)
                    .ThenInclude(p => p.ManufactureCountry)
                .Include(c => c.CartProducts)
                    .ThenInclude(c => c.Product)
                    .ThenInclude(p => p.Unit)
                .FirstOrDefaultAsync(predicate);

            return c;
        }
        public IEnumerable<Cart> ReadMany(Func<Cart, bool> predicate)
        {
            return _dbSet.AsNoTracking()
                 .Include(c => c.CartProducts)
                    .ThenInclude(c => c.Product)
                        .ThenInclude(p => p.Pictures)
                .Include(c => c.CartProducts)
                    .ThenInclude(c => c.Product)
                    .ThenInclude(p => p.ManufactureCountry)
                .Include(c => c.CartProducts)
                    .ThenInclude(c => c.Product)
                    .ThenInclude(p => p.Unit)
                .Where(predicate).AsEnumerable();
        }

        public async Task UpdateAsync(Cart item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cart item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
