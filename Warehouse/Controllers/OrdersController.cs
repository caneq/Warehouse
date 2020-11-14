using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Warehouse.Models;
using Warehouse.Data;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        [Authorize]
        public ActionResult Index()
        {
            var items = new OrderItem[]{
                new OrderItem{ OrderItemId = 1, Price = 100, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 1)},
                new OrderItem{ OrderItemId = 2, Price = 102, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 2)},

            };
            var resultPrice = items.Sum(i => i.Price);


            var l = new List<Order>();
            l.Add(new Order { OrderDate = DateTime.Now, OrderId = 2, UserId = 1, OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() });
            
            items = new OrderItem[]{
                new OrderItem{ OrderItemId = 3, Price = 3999.99f, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 5)},
                new OrderItem{ OrderItemId = 4, Price = 260.99f, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 3)},

            };
            resultPrice = items.Sum(i => i.Price);

            l.Add(new Order { OrderDate = DateTime.Today, OrderId = 1, UserId = 1, OrderStatus = _context.OrderStatuses.Find(3), TotalPrice = resultPrice, Items = items.ToList() });
            return View(l);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var items = new OrderItem[]{
                new OrderItem{ OrderItemId = 1, Price = 100, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 1)},
                new OrderItem{ OrderItemId = 2, Price = 102, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.ProductId == 2)},

            };
            var resultPrice = items.Sum(i => i.Price);

            Order o = new Order { OrderDate = DateTime.Now, OrderId = 2, UserId = 1, OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() };
            return View(o);
        }

        // GET: Orders/Create
        public ActionResult Create([FromQuery] int[] ids)
        {
            IQueryable<Product> products = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).Where(i => ids.Contains(i.ProductId));
            var items = new OrderItem[ids.Length];
            int i = 0;
            foreach(Product p in products)
            {
                items[i++] = new OrderItem {Product = p, ProductId = p.ProductId, Price = p.Price };
            }
            var resultPrice = items.Sum(i => i.Price);

            Order o = new Order { OrderDate = DateTime.Now, UserId = 1, OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() };

            return View(o);
        }

        public ActionResult Unprocessed()
        {
            return View();
        }

        // POST: Orders/Create
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

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Deliver(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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