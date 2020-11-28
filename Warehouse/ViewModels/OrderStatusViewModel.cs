using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class OrderStatusViewModel
    {
        public int Id { get; set; }
        public string OrderStatusString { get; set; }

        public override string ToString()
        {
            return OrderStatusString;
        }
    }
}
