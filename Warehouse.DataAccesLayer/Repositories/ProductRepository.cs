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
    class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }

        public async Task<int> CreateAsync(Product item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<Product> ReadAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
                .Include(p => p.Pictures)
                .Include(p => p.Unit)
                .Include(p => p.ManufactureCountry)
                .FirstOrDefaultAsync(predicate);
        }
        public IEnumerable<Product> ReadMany(Func<Product, bool> predicate)
        {
            return _dbSet.AsNoTracking().AsNoTracking()
                .Include(p => p.Pictures)
                .Include(p => p.Unit)
                .Include(p => p.Unit)
                .Where(predicate).AsEnumerable();
        }

        public async Task UpdateAsync(Product item)
        {
            var dbEnt = await _context.Products.Include(p => p.Pictures).FirstOrDefaultAsync(p => p.Id == item.Id);

            dbEnt.CountInStock = item.CountInStock;
            dbEnt.Description = item.Description;
            dbEnt.ManufactureCountryId = item.ManufactureCountryId;
            dbEnt.Name = item.Name;
            dbEnt.Price = item.Price;
            dbEnt.ShelfLife = item.ShelfLife;
            dbEnt.UnitId = item.UnitId;
            dbEnt.Weight = item.Weight;
            dbEnt.Pictures = item.Pictures;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

    }
}
