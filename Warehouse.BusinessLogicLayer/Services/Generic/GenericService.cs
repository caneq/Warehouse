using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.Interfaces.Generic;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.BusinessLogicLayer.Services.Generic
{
    public class GenericService<DTO, DAL> : IGenericService<DTO> 
        where DTO : class
        where DAL : class
    {
        protected readonly IRepository<DAL> _repo;
        protected readonly IMapper _mapper;

        public GenericService(IRepository<DAL> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(DTO item)
        {
            await _repo.CreateAsync(_mapper.Map<DAL>(item));
        }

        public async Task DeleteAsync(DTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<DAL>(item));
        }

        public async Task<DTO> ReadAsync(int id)
        {
            return _mapper.Map<DTO>(await _repo.ReadAsync(id));
        }

        public async Task UpdateAsync(DTO item)
        {
            var mappedItem = _mapper.Map<DAL>(item);
            await _repo.UpdateAsync(mappedItem);
        }
    }
}
