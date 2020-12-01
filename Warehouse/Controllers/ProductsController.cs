using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using AutoMapper;
using Warehouse.ViewModels;
using Warehouse.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Warehouse.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IUnitService _unitService;
        private readonly ICountriesService _countriesService;

        public ProductsController(IProductService productService, IUnitService unitService, IMapper mapper, ICountriesService countriesService)
        {
            _productService = productService;
            _mapper = mapper;
            _unitService = unitService;
            _countriesService = countriesService;
        }

        // GET: Products
        public ActionResult Index(ProductFilterParams f)
        {
            var a = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.ReadMany(f));
            return View(a);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                ProductViewModel p = _mapper.Map<ProductViewModel>(await _productService.ReadAsync(id));
                return View(p);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Units = new SelectList(_unitService.ReadAll(), "Id", "UnitString");
            ViewBag.Countries = new SelectList(_countriesService.ReadAll(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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