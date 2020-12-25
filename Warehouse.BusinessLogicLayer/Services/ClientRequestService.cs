using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using Warehouse.BusinessLogicLayer.Models;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;
using Warehouse.BusinessLogicLayer.Extensions;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class ClientRequestService : IClientRequestService
    {
        private readonly IClientRequestRepository _repo;
        private readonly IMapper _mapper;
        public ClientRequestService(IClientRequestRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(ClientRequestDTO item)
        {
            item.DateTime = DateTime.Now;
            item.Messages?.ForEach(a => a.DateTime = DateTime.Now);
            item.ManagersUnreadMessagesCount = 1;
            var c = await _repo.CreateAsync(_mapper.Map<ClientRequest>(item));
            return c;
        }

        public async Task DeleteAsync(ClientRequestDTO item)
        {
            await _repo.DeleteAsync(_mapper.Map<ClientRequest>(item));
        }

        public async Task<ClientRequestDTO> ReadAsync(int id)
        {
            return _mapper.Map<ClientRequestDTO>(await _repo.ReadAsync(p => p.Id == id));
        }

        public async Task<ClientRequestDTO> ReadAsync(ClientRequestFilterParams filterParams)
        {
            return _mapper.Map<ClientRequestDTO>(await _repo.ReadAsync(filterParams.GetLinqExpression()));
        }

        public async Task AddMessageAsync(int requestId, string messageText, ClaimsPrincipal User)
        {
            var request = await _repo.ReadAsync(r => r.Id == requestId);
            if (request.Messages == null) request.Messages = new List<ClientRequestMessage>();
            request.Messages.Add(new ClientRequestMessage 
            { 
                MessageText = messageText,
                ApplicationUserId = User.GetUserId(),
                ClientRequestId = requestId,
                DateTime = DateTime.Now 
            });

            if(User.Identity.Name == "User1@gmail.com")
            {
                request.ManagersUnreadMessagesCount++;
            }
            else
            {
                request.ClientUnreadMessagesCount++;
            }
            await _repo.UpdateAsync(request);
        }

        public IEnumerable<ClientRequestDTO> ReadMany(ClientRequestFilterParams filterParams)
        {
            return _mapper.Map<IEnumerable<ClientRequestDTO>>(_repo.ReadMany(filterParams.GetFuncPredicate()));
        }

        public async Task UpdateAsync(ClientRequestDTO item)
        {
            await _repo.UpdateAsync(_mapper.Map<ClientRequest>(item));
        }

        public async Task ReadMessagesAsync(int requestId, ClaimsPrincipal User)
        {
            var request = await _repo.ReadAsync(r => r.Id == requestId);

            if (User.GetUserId() == request.ApplicationUserId)
            {
                
                request.ClientUnreadMessagesCount = 0;
            }
            if(!User.Identity.Name.Contains("User", StringComparison.OrdinalIgnoreCase) 
                || User.Identity.Name.Contains("manager", StringComparison.OrdinalIgnoreCase))
            {
                request.ManagersUnreadMessagesCount = 0;
            }
            await _repo.UpdateAsync(request);
        }

        public async Task SetCompleted(int requestId, bool completed)
        {
            var request =  await _repo.ReadAsync(r => r.Id == requestId);
            request.Completed = completed;
            await _repo.UpdateAsync(request);
        }
    }
}
