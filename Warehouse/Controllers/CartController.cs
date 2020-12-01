using System.Collections.Generic;
using System.Linq;
using Warehouse.BusinessLogicLayer.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.ViewModels;
using AutoMapper;
using System.Security.Claims;
using Warehouse.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Warehouse.BusinessLogicLayer.Extensions;

namespace Warehouse.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService, IMapper mapper)
        {
            _mapper = mapper;
            _cartService = cartService;
        }

        // GET: Cart
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(_mapper.Map<CartViewModel>(await _cartService.GetCartAsync(User)));
            }
            catch (NotFoundException)
            {
                return View(null);
            }
            catch
            {
                return Unauthorized();
            }
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
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

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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
        public async Task<ActionResult> Add(int Productid)
        {
            try
            {
                await _cartService.AddCartProductAsync(new CartProductDTO { ProductId = Productid }, User);
                return Ok();
            }
            catch (UnauthorizeAccessException)
            {
                return StatusCode(403);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        //// GET: Cart/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Cart/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(int cartProductid)
        {
            try
            {
                await _cartService.DeleteCartProductAsync(cartProductid, User);
                return Ok();
            }
            catch (UnauthorizeAccessException)
            {
                return StatusCode(403);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
