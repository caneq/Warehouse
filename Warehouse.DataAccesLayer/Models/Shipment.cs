using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        public string RepicientName { get; set; }
        public string RepicientApplicationUserId { get; set; }
        public ApplicationUser Repicient { get; set; }

        public string ConveyedName { get; set; }
        public string ConveyedApplicationUserId { get; set; }
        public ApplicationUser Conveyed { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime DateTime { get; set; }
    }
}
