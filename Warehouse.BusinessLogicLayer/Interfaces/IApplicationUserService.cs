using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Models;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDTO> ReadAsync(string id);
        Task<ApplicationUserDTO> ReadAsync(ApplicationUserFilterParams filterParams);
        IEnumerable<ApplicationUserDTO> ReadMany(ApplicationUserFilterParams filterParams);
        Task CreateAsync(ApplicationUserDTO item);
        Task DeleteAsync(ApplicationUserDTO item);
        Task UpdateAsync(ApplicationUserDTO item);
    }
}
