using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class PaymentsController : Controller
    {
        ApplicationDbContext _context;
        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Payments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Payments
        public ActionResult UserOrders()
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

        // GET: Payments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
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

        // GET: Payments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payments/Edit/5
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

        // GET: Payments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payments/Delete/5
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