using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string OrderStatusString { get; set; }

        public override string ToString()
        {
            return OrderStatusString;
        }
    }
}
