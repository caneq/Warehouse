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
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> _repo;
        private readonly IMapper _mapper;
        public UnitService(IRepository<Unit> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IEnumerable<UnitDTO> ReadAll()
        {
            return _mapper.Map<IEnumerable<UnitDTO>>(_repo.ReadMany(u => true));
        }
    }
}
