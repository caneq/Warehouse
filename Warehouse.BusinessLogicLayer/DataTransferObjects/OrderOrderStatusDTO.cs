using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class OrderOrderStatusDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatusDTO OrderStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
}
