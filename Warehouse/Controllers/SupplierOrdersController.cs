using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccessLayer.Data;
using AutoMapper;
using Warehouse.ViewModels;
using Warehouse.ClassLibrary;
using Warehouse.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Extensions;

namespace Warehouse.Controllers
{
    public class SupplierOrdersController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly ISupplierOrderService _supplierOrderService;
        private readonly IProductService _productService;
        private readonly ISupplierOrderStatusService _supplierOrderStatusService;
        private readonly IMapper _mapper;
        public SupplierOrdersController(IMapper mapper, ISupplierService supplierService,
            ISupplierOrderService supplierOrderService, IProductService productService,
            ISupplierOrderStatusService supplierOrderStatusService)
        {
            _mapper = mapper;
            _supplierService = supplierService;
            _supplierOrderService = supplierOrderService;
            _productService = productService;
            _supplierOrderStatusService = supplierOrderStatusService;
        }
        public ActionResult Index()
        {
            var orders = _mapper.Map<IEnumerable<SupplierOrderViewModel>>(_supplierOrderService.ReadMany(User));
            return View(orders);
        }
        public ActionResult Unpaid()
        {
            var orders = _mapper.Map<IEnumerable<SupplierOrderViewModel>>(_supplierOrderService.ReadMany(User, 
                new SupplierOrderFilterParams { Status = "Ожидание оплаты" }));
            return View(orders);
        }
        public async Task<ActionResult> Pay(int id)
        {
            var order = _mapper.Map<SupplierOrderViewModel>(await _supplierOrderService.ReadAsync(User, id));
            return View(order);
        }

        public async Task<ActionResult> Details(int id)
        {
            var order = _mapper.Map<SupplierOrderViewModel>(await _supplierOrderService.ReadAsync(User, id));
            return View(order);
        }

        public ActionResult Create()
        {
            var defSelect = new SelectListItem { Value = "-1", Text = "Не выбрано", Selected = true };
            ViewBag.Suppliers = (new SelectList(_supplierService.ReadAll(), "Id", "Name")).Append(defSelect);
            ViewBag.Products = (new SelectList(_productService.ReadMany(new ProductFilterParams()), "Id", "Name")).Append(defSelect);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var supplierId = int.Parse(collection["SupplierId"].FirstOrDefault());
                var itemsIds = collection["Items"].Select(i => int.Parse(i));
                var Counts = collection["Counts"].Select(i => int.Parse(i));
                var Prices = collection["Prices"].Select(i => Price.Parse(i));

                var items = itemsIds.Zip(Counts).Zip(Prices).Select((idCountPrice) => new SupplierOrderItemDTO
                {
                    ProductId = idCountPrice.First.First,
                    Number = idCountPrice.First.Second,
                    SupplierOrderId = supplierId,
                    Price = idCountPrice.Second,

                });

                var supplierOrder = new SupplierOrderDTO 
                { 
                    SupplierId = int.Parse(collection["SupplierId"]),
                    UserId = User.GetUserId(), 
                    Items = items.ToList(),
                };

                await _supplierOrderService.Create(User, supplierOrder);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddStatus(int id, string status)
        {
            try
            {
                await _supplierOrderStatusService.SetByStatusString(id, status, User);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return RedirectToAction(nameof(Details), new { id });
            }

        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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