using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.PresentationLayer.ViewModel
{
    public class OrderStatusViewModel
    {
        public int OrderStatusId { get; set; }
        public string OrderStatusString { get; set; }

        public override string ToString()
        {
            return OrderStatusString;
        }
    }
}
