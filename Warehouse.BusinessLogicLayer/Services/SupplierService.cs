using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _repo;
        private readonly IMapper _mapper;
        public SupplierService(IRepository<Supplier> repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SupplierDTO item)
        {
            await _repo.CreateAsync(_mapper.Map<Supplier>(item));
        }

        public async Task DeleteAsync(SupplierDTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<Supplier>(item));
        }

        public IEnumerable<SupplierDTO> ReadAll()
        {
            return _mapper.Map<IEnumerable<SupplierDTO>>(_repo.ReadMany(s => true));
        }

        public async Task<SupplierDTO> ReadAsync(int id)
        {
            return _mapper.Map<SupplierDTO>(await _repo.ReadAsync(s => s.Id == id));
        }

        public async Task UpdateAsync(SupplierDTO item)
        {
            await _repo.UpdateAsync(_mapper.Map<Supplier>(item));
        }
    }
}
