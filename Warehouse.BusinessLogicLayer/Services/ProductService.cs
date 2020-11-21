using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.DataAccesLayer.Models;
using Warehouse.DataAccesLayer.Interfaces;

namespace Warehouse.BusinessLogicLayer.Services
{
    class ProductService : IProductService
    {
        public ProductService(IRepository<Product> repo)
        {

        }
        public void CreateAsync(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> Read(Func<ProductDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> ReadWithInclude(Func<ProductDTO, bool> predicate, params Expression<Func<ProductDTO, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(ProductDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
