﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccessLayer.Models;
using Warehouse.DataAccessLayer.Data;
using AutoMapper;
using Warehouse.ViewModels;
using Warehouse.ClassLibrary;
using Warehouse.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.Controllers
{
    public class SupplierOrdersController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly ISupplierOrderService _supplierOrderService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public SupplierOrdersController(IMapper mapper, ISupplierService supplierService,
            ISupplierOrderService supplierOrderService, IProductService productService)
        {
            _mapper = mapper;
            _supplierService = supplierService;
            _supplierOrderService = supplierOrderService;
            _productService = productService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            return View();
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