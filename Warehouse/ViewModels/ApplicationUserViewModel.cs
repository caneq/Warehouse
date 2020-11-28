using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class ApplicationUserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public CartViewModel Cart { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
