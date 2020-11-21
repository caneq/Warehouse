using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class ApplicationUserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public CartDTO Cart { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
