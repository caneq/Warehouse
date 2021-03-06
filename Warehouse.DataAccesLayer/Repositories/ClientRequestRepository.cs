﻿using Microsoft.EntityFrameworkCore;
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
                .Include(c => c.Messages)
                    .ThenInclude(c => c.User)
                .OrderByDescending(c => c.DateTime)
                .FirstOrDefaultAsync(predicate);

            return c;
        }

        public IEnumerable<ClientRequest> ReadMany(Func<ClientRequest, bool> predicate)
        {
            var requests = _dbSet.AsNoTracking()
                .Include(c => c.ApplicationUser)
                .Include(c => c.Messages)
                    .ThenInclude(c => c.User)
                .OrderByDescending(c => c.DateTime)
                .Where(predicate).AsEnumerable();

            requests.Select(r =>
            {
                r.Messages = r.Messages.OrderByDescending(o => o.DateTime).ToList();
                return r;
            });

            return requests;
        }

        public async Task UpdateAsync(ClientRequest item)
        {
            var req = await _dbSet
                .Include(c => c.ApplicationUser)
                .Include(c => c.Messages)
                    .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(r => r.Id == item.Id);

            req.ApplicationUserId = item.ApplicationUserId;
            req.ClientUnreadMessagesCount = item.ClientUnreadMessagesCount;
            req.Completed = item.Completed;
            req.ManagersUnreadMessagesCount = item.ManagersUnreadMessagesCount;

            var added = item.Messages.Where(s => !req.Messages.Any(o => o.Id == s.Id));
            var removed = req.Messages.Where(s => !item.Messages.Any(o => o.Id == s.Id));

            req.Messages.RemoveAll(m => removed.Contains(m));
            req.Messages.AddRange(added);

            req.Title = item.Title;
            
            await _context.SaveChangesAsync();
        }
    }
}
