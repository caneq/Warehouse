using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.DataAccesLayer.DataTransferObjects
{
    public class OrderStatusDTO
    {
        public int OrderStatusId { get; set; }
        public string OrderStatusString { get; set; }

        public override string ToString()
        {
            return OrderStatusString;
        }
    }
}
