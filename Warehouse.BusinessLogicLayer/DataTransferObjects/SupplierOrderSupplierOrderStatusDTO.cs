using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class SupplierOrderSupplierOrderStatusDTO
    {
        public int Id { get; set; }
        public int SupplierOrderId { get; set; }
        public SupplierOrderDTO SupplierOrder { get; set; }
        public int SupplierOrderStatusId { get; set; }
        public SupplierOrderStatusDTO SupplierOrderStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
}
