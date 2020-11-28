﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}
