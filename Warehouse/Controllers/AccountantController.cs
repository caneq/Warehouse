using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.ViewModels;

namespace Warehouse.Controllers
{
    public class AccountantController : Controller
    {
        private readonly IOrderService _ordersService;
        private readonly IOrderStatusesService _orderStatusesService;
        private readonly IMapper _mapper;
        public AccountantController(IOrderService ordersService, IOrderStatusesService orderStatusesService, IMapper mapper)
        {
            _ordersService = ordersService;
            _orderStatusesService = orderStatusesService;
            _mapper = mapper;
        }
        // GET: Accountand
        public ActionResult Index()
        {
            return View();
        }

    }
}
