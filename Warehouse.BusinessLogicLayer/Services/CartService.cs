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
        protected readonly ICartProductRepository _cartProductRepo;
        protected readonly IMapper _mapper;
        public CartService(IRepository<Cart> repo, ICartProductRepository cartProductRepo, IMapper mapper)
        {
            _repo = repo;
            _cartProductRepo = cartProductRepo;
            _mapper = mapper;
        }
        private async Task<Cart> _getCartAsync(ClaimsPrincipal User, string userId = null)
        {
            if (userId == null)
            {
                userId = User.GetUserId();
            }
            else if (userId != User.GetUserId() && !User.IsInRole("admin"))
            {
                throw new UnauthorizeAccessException();
            }
            return await _repo.ReadAsync(c => c.ApplicationUserId == userId);
        }
        public async Task AddCartProductAsync(CartProductDTO p, ClaimsPrincipal User, string userId = null)
        {
            CartProduct mappedCartProduct = _mapper.Map<CartProduct>(p);

            Cart cart = await _getCartAsync(User, userId);
            if (cart == null)
            {
                cart = new Cart { ApplicationUserId = userId ?? User.GetUserId(), CartProducts = new List<CartProduct> { mappedCartProduct } };
                await _repo.CreateAsync(cart);
            }
            else
            {
                mappedCartProduct.CartId = cart.Id;
                if (cart.CartProducts.Find(c => c.ProductId == mappedCartProduct.ProductId) == null)
                {
                    await _cartProductRepo.AddCartProductAsync(mappedCartProduct);
                }
            }
        }
        public async Task<CartDTO> GetCartAsync(ClaimsPrincipal User, string userId = null)
        {
            return _mapper.Map<CartDTO>(await _getCartAsync(User, userId));
        }
        public async Task<CartDTO> ReadAsync(int id)
        {
            return _mapper.Map<CartDTO>(await _repo.ReadAsync(c => c.Id == id));
        }
        public async Task<CartDTO> ReadAsync(CartFilterParams filterParams)
        {
            return _mapper.Map<CartDTO>(await _repo.ReadAsync(filterParams.GetLinqExpression()));
        }

        public async Task DeleteCartProductAsync(int CartProductId, ClaimsPrincipal User, string userId = null)
        {
            Cart cp = await _getCartAsync(User, userId);
            await _cartProductRepo.DeleteCartProductAsync(cp.CartProducts.Find(c => c.Id == CartProductId));
        }
    }
}
