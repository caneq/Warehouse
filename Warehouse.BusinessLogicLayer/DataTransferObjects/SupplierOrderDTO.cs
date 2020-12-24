using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.Services;
using Warehouse.ClassLibrary;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class SupplierOrderDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUserDTO User { get; set; }
        public int SupplierId { get; set; }
        public SupplierDTO Supplier { get; set; }
        public List<SupplierOrderItemDTO> Items { get; set; }
        public Price ResultPrice { get; set; }
        public List<SupplierOrderSupplierOrderStatusDTO> Statuses { get; set; }
    }
}
