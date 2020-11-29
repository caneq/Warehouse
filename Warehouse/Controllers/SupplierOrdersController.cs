using System;
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

namespace Warehouse.Controllers
{
    public class SupplierOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SupplierOrdersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: SupplierOrders
        public ActionResult Index()
        {
            var items = new OrderItem[]{
                new OrderItem{ Id = 1, Price = new Price(100), Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 3)},
                new OrderItem{ Id = 2, Price = new Price(102), Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 4)},

            };
            var resultPrice = new Price(items.Sum(i => i.Price.Penny));


            var l = new List<Order>();
            l.Add(new Order { OrderDate = DateTime.Now, Id = 2, UserId = "123", OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() });

            items = new OrderItem[]{
                new OrderItem{ Id = 3, Price = new Price(399999), Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 5)},
                new OrderItem{ Id = 4, Price = new Price(26099), Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 1)},

            };
            resultPrice = new Price(items.Sum(i => i.Price.Penny));

            l.Add(new Order { OrderDate = DateTime.Today, Id = 1, UserId = "123", OrderStatus = _context.OrderStatuses.Find(3), TotalPrice = resultPrice, Items = items.ToList() });
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(l));
        }

        // GET: SupplierOrders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var items = new OrderItem[]{
                new OrderItem{ Id = 1, Price = new Price(10000), Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 3)},
                new OrderItem{ Id = 2, Price = new Price(10200), Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 4)},

            };
            var resultPrice = new Price(items.Sum(i => i.Price.Penny));

            Order o = new Order { OrderDate = DateTime.Now, Id = 2, UserId = "123", OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() };
            return View(_mapper.Map<OrderViewModel>(o));
        }

        // GET: SupplierOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierOrders/Create
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

        // GET: SupplierOrders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierOrders/Edit/5
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

        // GET: SupplierOrders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierOrders/Delete/5
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