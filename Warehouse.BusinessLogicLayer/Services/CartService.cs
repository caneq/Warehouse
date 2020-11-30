using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Exceptions;
using Warehouse.BusinessLogicLayer.Extensions;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    class CartService : ICartService
    {
        protected readonly IRepository<Cart> _repo;
        protected readonly IMapper _mapper;
        public CartService(IRepository<Cart> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddCartProductAsync(CartProductDTO p, ClaimsPrincipal User, string userId = null)
        {
            if (userId == null)
            {
                userId = User.GetUserId();
            }
            else if (userId != User.GetUserId() && !User.IsInRole("admin"))
            {
                throw new UnauthorizeAccessException();
            }

            Cart cart = await _repo.ReadAsync(c => c.ApplicationUserId == userId);
            CartProduct mappedCartProduct = _mapper.Map<CartProduct>(p);
            if (cart == null)
            {
                var list = new List<CartProduct>
                {
                    mappedCartProduct
                };
                cart = new Cart { ApplicationUserId = userId, CartProducts = new List<CartProduct> { mappedCartProduct } };
                await _repo.CreateAsync(cart);
            }
            else
            {
                cart.CartProducts.Add(mappedCartProduct);
                await _repo.UpdateAsync(cart);
            }
        }
        public async Task<CartDTO> GetCartAsync(ClaimsPrincipal User, string userId = null)
        {
            if (userId == null)
            {
                userId = User.GetUserId();
            }
            else if (userId != User.GetUserId() && !User.IsInRole("admin"))
            {
                throw new UnauthorizeAccessException();
            }
            return _mapper.Map<CartDTO>(await _repo.ReadAsync(c => c.ApplicationUserId == userId));
        }
        public async Task<CartDTO> ReadAsync(int id)
        {
            return _mapper.Map<CartDTO>(await _repo.ReadAsync(c => c.Id == id));
        }
        public async Task<CartDTO> ReadAsync(CartFilterParams filterParams)
        {
            return _mapper.Map<CartDTO>(await _repo.ReadAsync(filterParams.GetLinqExpression()));
        }
        public IEnumerable<CartDTO> ReadMany(CartFilterParams filterParams)
        {
            return _mapper.Map<IEnumerable<CartDTO>>(_repo.ReadMany(filterParams.GetFuncPredicate()));
        }
        public async Task CreateAsync(CartDTO item)
        {
            await _repo.CreateAsync(_mapper.Map<Cart>(item));
        }
        public async Task DeleteAsync(CartDTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<Cart>(item));
        }
        public async Task UpdateAsync(CartDTO item)
        {
            var mappedItem = _mapper.Map<Cart>(item);
            await _repo.UpdateAsync(mappedItem);
        }
    }
}
