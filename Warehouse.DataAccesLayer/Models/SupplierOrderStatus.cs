using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    public class SupplierOrderStatus
    {
        public int Id { get; set; }
        public string String { get; set; }
        public List<SupplierOrder> SupplierOrders { get; set; }
    }
}
