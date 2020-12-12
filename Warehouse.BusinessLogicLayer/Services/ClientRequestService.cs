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

        public async Task AddMessageAsync(int id, string messageText, ClaimsPrincipal User)
        {
            var request = await _repo.ReadAsync(r => r.Id == id);
            if (request.Messages == null) request.Messages = new List<ClientRequestMessage>();
            request.Messages.Add(new ClientRequestMessage { MessageText = messageText, ApplicationUserId = User.GetUserId(), ClientRequestId = id });

            if(User.Identity.Name.Contains("User", StringComparison.OrdinalIgnoreCase))
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
    }
}
