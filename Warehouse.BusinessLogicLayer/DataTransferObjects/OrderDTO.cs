﻿using System;
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
        public string UserId { get; set; }
        public ApplicationUserDTO User { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public Price TotalPrice { get; set; }
        public List<OrderOrderStatusDTO> OrderStatuses { get; set; }
        public List<ShipmentDTO> Shipments { get; set; }
    }
}
