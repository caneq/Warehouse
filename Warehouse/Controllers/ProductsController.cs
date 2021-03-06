﻿using System;
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

        public ActionResult Index(ProductFilterParams f)
        {
            if (f.MinCount == null) f.MinCount = 1;
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.ReadMany(f));
            var viewModel = _mapper.Map<ProductFilterViewModel>(f);
            viewModel.Products = products;
            return View(viewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                ProductViewModel p = _mapper.Map<ProductViewModel>(await _productService.ReadAsync(id));
                if (p == null) Response.StatusCode = 404;
                return View(p);
            }
            catch
            {
                return NotFound();
            }
        }

        public ActionResult Create()
        {
            ViewBag.Units = new SelectList(_unitService.ReadAll(), "Id", "UnitString");
            ViewBag.Countries = new SelectList(_countriesService.ReadAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel p, IFormCollection collection)
        {
            try
            {
                p.Pictures = collection["pictures"].Select(s => new UrlViewModel { UrlString = s }).ToList();
                var id = await _productService.CreateAsync(_mapper.Map<ProductDTO>(p));
                return RedirectToAction(nameof(Details), new { Id = id });
            }
            catch
            {
                return Create();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var defSelect = new SelectListItem { Value = "-1", Text = "Не выбрано", Selected = true };
            ViewBag.Units = (new SelectList(_unitService.ReadAll(), "Id", "UnitString")).Append(defSelect);
            ViewBag.Countries = (new SelectList(_countriesService.ReadAll(), "Id", "Name")).Append(defSelect);
            return View(_mapper.Map<ProductViewModel>(await _productService.ReadAsync(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductViewModel p, IFormCollection collection)
        {
            try
            {
                p.Pictures = collection["pictures"].Select(s => new UrlViewModel { UrlString = s }).ToList();
                await _productService.UpdateAsync(_mapper.Map<ProductDTO>(p));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var product = await _productService.ReadAsync(id);
                if (product == null) return NotFound();
                await _productService.DeleteAsync(product);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
