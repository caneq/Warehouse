using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    public class SupplierOrderStatusSupplierOrder
    {
        public int Id { get; set; }
        public int SupplierOrderId { get; set; }
        public SupplierOrder SupplierOrder { get; set; }
        public int SupplierOrderStatusId { get; set; }
        public SupplierOrderStatus SupplierOrderStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
}
