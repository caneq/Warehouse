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
        private readonly IDocumentService _documentService;
        public ShipmentsController(IMapper mapper, IShipmentService service, IDocumentService documentService)
        {
            _mapper = mapper;
            _service = service;
            _documentService = documentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DownloadDocx(int id)
        {
            try
            {
                var shipment = await _service.ReadAsync(id);
                if (shipment == null) return NotFound();
                var documentStream = _documentService.CreateWordInvoice(shipment);

                return File(documentStream,
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    $"invoice_{id}.docx");
            }
            catch
            {
                return StatusCode(500);
            }
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
