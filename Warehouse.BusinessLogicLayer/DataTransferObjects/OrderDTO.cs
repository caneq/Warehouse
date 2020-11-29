using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public ApplicationUserDTO User { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public Price TotalPrice { get; set; }
        public OrderStatusDTO OrderStatus { get; set; }
    }
}
