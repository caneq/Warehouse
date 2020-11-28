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
using Warehouse.BusinessLogicLayer.Services.Generic;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class ProductService : GenericService<ProductDTO, Product>, IProductService
    {
        public ProductService(IRepository<Product> repo, IMapper mapper)
            : base(repo, mapper)
        {
        }

        public async Task<ProductDTO> ReadWithIncludeAsync(int id)
        {
            return _mapper.Map<ProductDTO>(await _repo.ReadFirstWithIncludeAsync(p=>p.Id == id));
        }
        private Func<Product, bool> _predicateFromFilterParams(ProductFilterParams f)
        {
            return (Product p) => p.CountInStock > (f.MinCount ?? int.MinValue) &&
            p.CountInStock < (f.MaxCount ?? int.MaxValue) &&
            p.Weight < (f.MaxWeight ?? float.MaxValue);
        }
        public IEnumerable<ProductDTO> ReadMany(ProductFilterParams filterParams)
        {
            var filterPredicate = _predicateFromFilterParams(filterParams);
            return _mapper.Map<IEnumerable<ProductDTO>>(_repo.ReadMany(filterPredicate));
        }
        public IEnumerable<ProductDTO> ReadManyWithInclude(ProductFilterParams filterParams)
        {
            var filterPredicate = _predicateFromFilterParams(filterParams);
            return _mapper.Map<IEnumerable<ProductDTO>>(_repo.ReadManyWithInclude(filterPredicate));
        }
    }
}
