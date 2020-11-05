using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}
