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
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _repo;
        private readonly IMapper _mapper;
        public ShipmentService(IShipmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> CreateAsync(ShipmentDTO item)
        {
            item.DateTime = DateTime.Now;
            return await _repo.CreateAsync(_mapper.Map<Shipment>(item));
        }

        public async Task DeleteAsync(ShipmentDTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<Shipment>(item));
        }

        public async Task<ShipmentDTO> ReadAsync(int id)
        {
            return _mapper.Map<ShipmentDTO>(await _repo.ReadAsync(p => p.Id == id));
        }

        public async Task<ShipmentDTO> ReadAsync(ShipmentFilterParams filterParams)
        {
            return _mapper.Map<ShipmentDTO>(await _repo.ReadAsync(filterParams.GetLinqExpression()));
        }

        public IEnumerable<ShipmentDTO> ReadMany(ShipmentFilterParams filterParams)
        {
            return _mapper.Map<IEnumerable<ShipmentDTO>>(_repo.ReadMany(filterParams.GetFuncPredicate()));
        }

        public async Task UpdateAsync(ShipmentDTO item)
        {
            var mappedItem = _mapper.Map<Shipment>(item);
            await _repo.UpdateAsync(mappedItem);
        }
    }
}
