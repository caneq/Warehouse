using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
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
