using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Services
{
    class CountriesService : ICountriesService
    {
        private readonly IRepository<Country> _repo;
        private readonly IMapper _mapper;
        public CountriesService(IRepository<Country> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IEnumerable<CountryDTO> ReadAll()
        {
            return _mapper.Map<IEnumerable<CountryDTO>>(_repo.ReadMany(u => true));
        }
    }
}
