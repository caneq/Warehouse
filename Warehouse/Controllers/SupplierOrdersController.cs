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
                new OrderItem{ OrderItemId = 1, Price = 100, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 3)},
                new OrderItem{ OrderItemId = 2, Price = 102, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 4)},

            };
            var resultPrice = items.Sum(i => i.Price);


            var l = new List<Order>();
            l.Add(new Order { OrderDate = DateTime.Now, OrderId = 2, UserId = "123", OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() });

            items = new OrderItem[]{
                new OrderItem{ OrderItemId = 3, Price = 3999.99f, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 5)},
                new OrderItem{ OrderItemId = 4, Price = 260.99f, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 1)},

            };
            resultPrice = items.Sum(i => i.Price);

            l.Add(new Order { OrderDate = DateTime.Today, OrderId = 1, UserId = "123", OrderStatus = _context.OrderStatuses.Find(3), TotalPrice = resultPrice, Items = items.ToList() });
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(l));
        }

        // GET: SupplierOrders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var items = new OrderItem[]{
                new OrderItem{ OrderItemId = 1, Price = 100, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 3)},
                new OrderItem{ OrderItemId = 2, Price = 102, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 4)},

            };
            var resultPrice = items.Sum(i => i.Price);

            Order o = new Order { OrderDate = DateTime.Now, OrderId = 2, UserId = "123", OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() };
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