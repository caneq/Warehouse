﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Warehouse.DataAccessLayer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<OrderItem> Items { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
