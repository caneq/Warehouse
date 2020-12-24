using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.ViewModels;

namespace Warehouse.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(_supplierService.ReadAll());
            return View(suppliers);
        }

        public async Task<ActionResult> Details(int id)
        {
            var supplier = _mapper.Map<SupplierViewModel>(await _supplierService.ReadAsync(id));
            return View(supplier);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SupplierDTO supplier)
        {
            try
            {
                await _supplierService.CreateAsync(supplier);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var supplier = _mapper.Map<SupplierViewModel>(await _supplierService.ReadAsync(id));
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SupplierDTO supplier)
        {
            try
            {
                await _supplierService.UpdateAsync(supplier);

                return RedirectToAction(nameof(Details), new { id = supplier.Id });
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var sup = _mapper.Map<SupplierViewModel>(await _supplierService.ReadAsync(id));
            return View(sup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var sup = await _supplierService.ReadAsync(id);
                if (sup == null) return NotFound();

                await _supplierService.DeleteAsync(sup);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Details), new { id });
            }
        }
    }
}
