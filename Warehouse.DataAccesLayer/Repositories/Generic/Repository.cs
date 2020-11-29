using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Data;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        private IQueryable<T> Include()
        {
            var query = _context.Set<T>().AsNoTracking().AsQueryable();

            var navigations = _context.Model.FindEntityType(typeof(T))
                .GetDerivedTypesInclusive()
                .SelectMany(type => type.GetNavigations())
                .Distinct();

            foreach (var property in navigations)
                query = query.Include(property.Name);

            return query;
        }
        public async Task CreateAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<T> ReadAsync(Expression<Func<T, bool>> p)
        {
            return await _dbSet.FirstOrDefaultAsync(p);
        }
        public async Task<T> ReadFirstWithIncludeAsync(Expression<Func<T, bool>> predicate)
        {
            return await Include().FirstOrDefaultAsync(predicate);
        }
        public IEnumerable<T> ReadMany(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public IEnumerable<T> ReadManyWithInclude(Func<T, bool> predicate)
        {
            return Include().Where(predicate).ToList();
        }

        public async Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

    }
}
