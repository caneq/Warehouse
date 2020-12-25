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
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ApplicationUser> _repo;

        public ApplicationUserService(IMapper mapper, IRepository<ApplicationUser> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task CreateAsync(ApplicationUserDTO item)
        {
            await _repo.CreateAsync(_mapper.Map<ApplicationUser>(item));
        }

        public async Task DeleteAsync(ApplicationUserDTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<ApplicationUser>(item));
        }

        public async Task<ApplicationUserDTO> ReadAsync(string id)
        {
            return _mapper.Map<ApplicationUserDTO>(await _repo.ReadAsync(u => u.Id == id));
        }

        public async Task<ApplicationUserDTO> ReadAsync(ApplicationUserFilterParams filterParams)
        {
            return _mapper.Map<ApplicationUserDTO>(await _repo.ReadAsync(filterParams.GetLinqExpression()));
        }

        public IEnumerable<ApplicationUserDTO> ReadMany(ApplicationUserFilterParams filterParams)
        {
            return _mapper.Map<IEnumerable<ApplicationUserDTO>>(_repo.ReadMany(filterParams.GetFuncPredicate()));
        }

        public async Task UpdateAsync(ApplicationUserDTO item)
        {
            await _repo.UpdateAsync(_mapper.Map<ApplicationUser>(item));
        }
    }
}
