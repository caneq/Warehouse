using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public CartDTO Cart { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
