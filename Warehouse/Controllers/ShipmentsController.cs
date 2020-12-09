using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.ViewModels;

namespace Warehouse.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IShipmentService _service;
        public ShipmentsController(IMapper mapper, IShipmentService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipmentViewModel shipment)
        {
            try
            {
                await _service.CreateAsync(_mapper.Map<ShipmentDTO>(shipment));
                return Redirect($"/orders/details/{shipment.OrderId}");
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
