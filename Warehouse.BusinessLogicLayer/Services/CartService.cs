using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.BusinessLogicLayer.Services.Generic;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    class CartService : GenericService<CartDTO, Cart>, ICartService
    {
        public CartService(IRepository<Cart> repo, IMapper mapper)
            : base(repo, mapper)
        {
        }
        private Func<Cart, bool> _predicateFromFilterParams(CartFilterParams f)
        {
            throw new NotImplementedException();
            //return (Product p) => p.CountInStock > (f.MinCount ?? int.MinValue) &&
            //p.CountInStock < (f.MaxCount ?? int.MaxValue) &&
            //p.Weight < (f.MaxWeight ?? float.MaxValue);
        }
        public IEnumerable<CartDTO> ReadMany(CartFilterParams filterParams)
        {
            var filterPredicate = _predicateFromFilterParams(filterParams);
            return _mapper.Map<IEnumerable<CartDTO>>(_repo.ReadMany(filterPredicate));
        }

        public IEnumerable<CartDTO> ReadManyWithInclude(CartFilterParams filterParams)
        {
            var filterPredicate = _predicateFromFilterParams(filterParams);
            return _mapper.Map<IEnumerable<CartDTO>>(_repo.ReadManyWithInclude(filterPredicate));
        }

        public async Task<CartDTO> ReadWithIncludeAsync(int id)
        {
            return _mapper.Map<CartDTO>(await _repo.ReadFirstWithIncludeAsync(p => p.CartId == id));
        }
    }
}
