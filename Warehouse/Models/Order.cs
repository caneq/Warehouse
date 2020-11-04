using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Warehouse.Models
{
    public class Order
    {
        public int OrderId;
        public DateTime OrderDate;
        public int UserId;
        public IdentityUser User;
        public List<(Product, float)> Products;
        public float TotalPrice;
        public OrderStatus OrderStatus;
    }
}
