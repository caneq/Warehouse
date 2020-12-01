using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class OrderOrderStatusViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatusViewModel OrderStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
}
