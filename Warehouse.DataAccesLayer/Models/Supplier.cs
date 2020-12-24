using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PaymentDetails { get; set; }
        public List<SupplierOrder> SupplierOrders { get; set; }
    }
}
