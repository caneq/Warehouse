using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Warehouse.ClassLibrary;

namespace Warehouse.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUserViewModel User { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public Price TotalPrice { get; set; }
        public List<OrderOrderStatusViewModel> OrderStatuses { get; set; }
    }
}
