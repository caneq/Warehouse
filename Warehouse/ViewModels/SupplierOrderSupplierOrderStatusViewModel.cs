using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class SupplierOrderSupplierOrderStatusViewModel
    {
        public int Id { get; set; }
        public int SupplierOrderId { get; set; }
        public SupplierOrderViewModel SupplierOrder { get; set; }
        public int SupplierOrderStatusId { get; set; }
        public SupplierOrderStatusViewModel SupplierOrderStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
}
