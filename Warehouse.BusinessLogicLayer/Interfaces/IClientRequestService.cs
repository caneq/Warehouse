using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IClientRequestService
    {
        Task<ClientRequestDTO> ReadAsync(int id);
        Task<ClientRequestDTO> ReadAsync(ClientRequestFilterParams filterParams);
        IEnumerable<ClientRequestDTO> ReadMany(ClientRequestFilterParams filterParams);
        Task<int> CreateAsync(ClientRequestDTO item);
        Task DeleteAsync(ClientRequestDTO item);
        Task UpdateAsync(ClientRequestDTO item);
        Task AddMessageAsync(int requestId, string messageText, ClaimsPrincipal User);
        Task ReadMessagesAsync(int requestId, ClaimsPrincipal User);
    }
}
