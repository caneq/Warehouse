using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;
using Warehouse.DataAccessLayer.Interfaces;
using AutoMapper;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repo;
        private IMapper _mapper;
        public ProductService(IRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(ProductDTO item)
        {
            await _repo.CreateAsync(_mapper.Map<Product>(item));
        }

        public IEnumerable<ProductDTO> Read(Func<ProductDTO, bool> predicate)
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_mapper.Map<Func<Product, bool>>(predicate));
        }

        public async Task<ProductDTO> ReadAsync(int id)
        {
            return _mapper.Map<ProductDTO>(await _repo.ReadAsync(id));
        }

        public IEnumerable<ProductDTO> ReadWithInclude(Func<ProductDTO, bool> predicate, params Expression<Func<ProductDTO, object>>[] includeProperties)
        {
            var mappedPredicate = _mapper.Map<Func<Product, bool>>(predicate);
            var mappedIncludeProperties = _mapper.Map<Expression<Func<Product, object>>[]>(includeProperties);
            return _mapper.Map<IEnumerable<ProductDTO>>(_repo.ReadWithInclude(mappedPredicate, mappedIncludeProperties));
        }

        public async Task UpdateAsync(ProductDTO item)
        {
            var mappedItem = _mapper.Map<Product>(item);
            await _repo.UpdateAsync(mappedItem);
        }

        public async Task DeleteAsync(ProductDTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<Product>(item));
        }

    }
}
