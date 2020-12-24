using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.ClassLibrary;

namespace Warehouse.DataAccessLayer.Models
{
    public class SupplierOrder
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<SupplierOrderItem> Items { get; set; }
        public Price ResultPrice { get; set; }
        public List<SupplierOrderSupplierOrderStatus> Statuses { get; set; }

    }
}
