using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;
using Warehouse.DataAccessLayer.Interfaces;
using AutoMapper;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepository _repo;
        protected readonly IMapper _mapper;
        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ProductDTO> ReadAsync(int id)
        {
            return _mapper.Map<ProductDTO>(await _repo.ReadAsync(p => p.Id == id));
        }
        public async Task<ProductDTO> ReadAsync(ProductFilterParams filterParams)
        {
            return _mapper.Map<ProductDTO>(await _repo.ReadAsync(filterParams.GetLinqExpression()));
        }
        public IEnumerable<ProductDTO> ReadMany(ProductFilterParams filterParams)
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_repo.ReadMany(filterParams.GetFuncPredicate()));
        }
        public async Task<int> CreateAsync(ProductDTO item)
        {
            if (item.ShelfLife == null) item.ShelfLife = int.MaxValue;
            return await _repo.CreateAsync(_mapper.Map<Product>(item));
        }
        public async Task DeleteAsync(ProductDTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<Product>(item));
        }
        public async Task UpdateAsync(ProductDTO item)
        {
            var mappedItem = _mapper.Map<Product>(item);
            await _repo.UpdateAsync(mappedItem);
        }
    }
}
