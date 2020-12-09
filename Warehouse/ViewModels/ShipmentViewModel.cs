using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class ShipmentViewModel
    {
        public int Id { get; set; }

        public string RepicientName { get; set; }
        public string RepicientApplicationUserId { get; set; }
        public ApplicationUserViewModel Repicient { get; set; }

        public string ConveyedName { get; set; }
        public string ConveyedApplicationUserId { get; set; }
        public ApplicationUserViewModel Conveyed { get; set; }

        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public DateTime DateTime { get; set; }
    }
}
