using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccessLayer.Models;
using Warehouse.DataAccessLayer.Data;

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
                new OrderItem{ Id = 1, Price = 100, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 1)},
                new OrderItem{ Id = 2, Price = 102, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 2)},

            };
            var resultPrice = items.Sum(i => i.Price);


            var l = new List<Order>();
            l.Add(new Order { OrderDate = DateTime.Now, Id = 2, UserId = "123", OrderStatus = _context.OrderStatuses.Find(1), TotalPrice = resultPrice, Items = items.ToList() });

            items = new OrderItem[]{
                new OrderItem{ Id = 3, Price = 3999.99f, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 5)},
                new OrderItem{ Id = 4, Price = 260.99f, Product = _context.Products.Include(p => p.Pictures).Include(p => p.Unit)
                    .Include(p => p.ManufactureCountry).FirstOrDefault(i=>i.Id == 3)},

            };
            resultPrice = items.Sum(i => i.Price);

            l.Add(new Order { OrderDate = DateTime.Today, Id = 1, UserId = "123", OrderStatus = _context.OrderStatuses.Find(3), TotalPrice = resultPrice, Items = items.ToList() });
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