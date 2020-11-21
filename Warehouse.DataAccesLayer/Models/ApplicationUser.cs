using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccesLayer.Models;

namespace Warehouse.DataAccesLayer.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}
