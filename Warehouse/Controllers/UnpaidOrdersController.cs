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
    public class UnpaidOrdersController : Controller
    {
        private readonly IOrderService _ordersService;
        private readonly IOrderStatusesService _orderStatusesService;
        private readonly IMapper _mapper;
        public UnpaidOrdersController(IOrderService ordersService, IOrderStatusesService orderStatusesService, IMapper mapper)
        {
            _ordersService = ordersService;
            _orderStatusesService = orderStatusesService;
            _mapper = mapper;
        }
        // GET: UnpaidOrders
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(
                _ordersService.ReadMany(User, new OrderFilterParams { OrderStatus = await _orderStatusesService.GetByStatusStringAsync("Ожидание оплаты") })));
        }

        // GET: UnpaidOrders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnpaidOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnpaidOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnpaidOrders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnpaidOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnpaidOrders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnpaidOrders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}