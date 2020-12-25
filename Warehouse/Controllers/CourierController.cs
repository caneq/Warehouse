using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.BusinessLogicLayer.Extensions;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.ViewModels;

namespace Warehouse.Controllers
{
    public class CourierController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        public CourierController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(_service.ReadMany(User, new OrderFilterParams { UserId = "1" })));
        }

        public IActionResult Deliver()
        {
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(_service.ReadMany(User, new OrderFilterParams { LastShippedForUserId = User.GetUserId(), OrderStatusString = "Передан курьеру" })));
        }
    }
}
