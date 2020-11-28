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

        public async Task<CartDTO> ReadWithIncludeAsync(int id)
        {
            return _mapper.Map<CartDTO>(await _repo.ReadFirstWithIncludeAsync(p => p.Id == id));
        }

        public async Task<CartDTO> ReadByUserIdWithIncludeAsync(string id)
        {
            var a = await _repo.ReadFirstWithIncludeAsync(p => p.ApplicationUserId == id);
            return _mapper.Map<CartDTO>(await _repo.ReadFirstWithIncludeAsync(p => p.ApplicationUserId == id));
        }
    }
}
