using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    public class OrderOrderStatus
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
}
