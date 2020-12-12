using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.ViewModels;

namespace Warehouse.Controllers
{
    public class ClientRequestsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClientRequestService _service;
        public ClientRequestsController(IMapper mapper, IClientRequestService service)
        {
            _mapper = mapper;
            _service = service;
        }
        // GET: ClientRequests
        public ActionResult Index()
        {
            var requests = _service.ReadMany(new ClientRequestFilterParams { });
            return View(_mapper.Map<IEnumerable<ClientRequestViewModel>>(requests));
        }

        // GET: ClientRequests/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var request = await _service.ReadAsync(id);
            return View(_mapper.Map<ClientRequestViewModel>(request));
        }

        // GET: ClientRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMessage(int id, string MessageText)
        {
            //try
            //{
                await _service.AddMessageAsync(id, MessageText, User);
                return RedirectToAction(nameof(Details), new { id });
            //}
            //catch
            //{
            //    return BadRequest();
            //}
        }

        // POST: ClientRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientRequestDTO request, IFormCollection collection)
        {
            try
            {
                var messageText = collection["MessageText"].FirstOrDefault();
                request.Messages = new List<ClientRequestMessageDTO>
                {
                    new ClientRequestMessageDTO { ApplicationUserId = request.ApplicationUserId, MessageText = messageText},
                };

                int id = await _service.CreateAsync(request);

                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientRequests/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientRequests/Edit/5
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

        // GET: ClientRequests/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientRequests/Delete/5
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