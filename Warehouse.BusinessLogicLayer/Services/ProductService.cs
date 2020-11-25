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

        public async Task<ProductDTO> ReadAsync(int id)
        {
            return _mapper.Map<ProductDTO>(await _repo.ReadAsync(id));
        }
        private Func<Product, bool> _predicateFromFilterParams(ProductFilterParams f)
        {
            return (Product p) => p.CountInStock > (f.MinCount ?? int.MinValue) &&
            p.CountInStock < (f.MaxCount ?? int.MaxValue) &&
            p.Weight < (f.MaxWeight ?? float.MaxValue);
        }
        public IEnumerable<ProductDTO> Read(ProductFilterParams filterParams)
        {
            var filterPredicate = _predicateFromFilterParams(filterParams);
            return _mapper.Map<IEnumerable<ProductDTO>>(_repo.ReadWithInclude(filterPredicate, p=>p.Pictures, p=>p.ManufactureCountry, p=>p.Unit));
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
