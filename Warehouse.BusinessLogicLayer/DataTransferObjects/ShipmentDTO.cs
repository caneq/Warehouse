using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class ShipmentDTO
    {
        public int Id { get; set; }

        public string RepicientName { get; set; }
        public string RepicientApplicationUserId { get; set; }
        public ApplicationUserDTO Repicient { get; set; }

        public string СonveyedName { get; set; }
        public string СonveyedApplicationUserId { get; set; }
        public ApplicationUserDTO Сonveyed { get; set; }

        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public DateTime DateTime { get; set; }
    }
}
