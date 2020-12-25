using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccessLayer.Models;
using Warehouse.DataAccessLayer.Data;
using AutoMapper;
using Warehouse.ViewModels;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.ClassLibrary;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.BusinessLogicLayer.Exceptions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Warehouse.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IOrderStatusesService _orderStatusesService;
        private readonly IApplicationUserService _userService;
        public OrdersController(IOrderService orderService, IProductService productService,
            IOrderStatusesService orderStatusesService, IMapper mapper, IApplicationUserService userService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _productService = productService;
            _orderStatusesService = orderStatusesService;
            _userService = userService;
        }

        // GET: Orders
        [Authorize]
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(_orderService.ReadMany(User)));
        }

        public async Task<ActionResult> Unpaid()
        {
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(
                _orderService.ReadMany(User, new OrderFilterParams { OrderStatus = await _orderStatusesService.GetByStatusStringAsync("Ожидание оплаты") })));
        }

        public IActionResult All()
        {
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(
                _orderService.ReadMany(User, new OrderFilterParams {})));
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //var users = new ApplicationUserViewModel[] {
            //    new ApplicationUserViewModel{ Id = "304bef4a-d060-40c0-9794-999984f304d5", UserName = "Courier1@gmail.com"},
            //};
            var users = _mapper.Map<IEnumerable<ApplicationUserViewModel>>(_userService.ReadMany(new ApplicationUserFilterParams { UserNameContains = "courier" }));
            ViewBag.Couriers = new SelectList(users, "Id", "UserName");
            return View(_mapper.Map<OrderViewModel>(await _orderService.ReadAsync(User, id)));
        }

        public ActionResult Create([FromQuery] int[] ids)
        {
            IEnumerable<ProductViewModel> products = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.ReadMany(new ProductFilterParams { Ids = ids }));
            return View(products);
        }

        [HttpPost]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            IEnumerable<ProductDTO> products = null; 
            try
            {
                var ids = collection["ids[]"];
                products = _productService.ReadMany(new ProductFilterParams { Ids = ids.Select(int.Parse) });
                await _orderService.Create(User, products);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                try
                {
                    return View(_mapper.Map<ProductViewModel>(products));
                }
                catch
                {
                    return View(null);
                }
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

        [HttpPost]
        public async Task<ActionResult> SetPayed(int id)
        {
            try
            {
                await _orderStatusesService.SetPayed(id, User);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch
            {
                return BadRequest();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        public async Task<ActionResult> Deliver(int id)
        {
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(
                _orderService.ReadMany(User, new OrderFilterParams { OrderStatus = await _orderStatusesService.GetByStatusStringAsync("Ожидание доставки") })));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}