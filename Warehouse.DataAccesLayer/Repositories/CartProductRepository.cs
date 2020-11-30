using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Data;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Repositories
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly ApplicationDbContext _context;
        public CartProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCartProductAsync(CartProduct item)
        {
            await _context.CartProducts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartProductAsync(CartProduct item)
        {
            _context.CartProducts.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
