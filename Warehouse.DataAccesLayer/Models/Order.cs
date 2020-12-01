using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Warehouse.ClassLibrary;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Models
{
    public class Order : IDataModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<OrderItem> Items { get; set; }
        public Price TotalPrice { get; set; }
        public List<OrderOrderStatus> OrderStatuses { get; set; }
    }
}
