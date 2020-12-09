using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;

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
            return View();
        }

        public IActionResult Deliver()
        {
            return View();
        }
    }
}