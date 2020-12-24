using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.ViewModels
{
    public class SupplierOrderViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUserViewModel User { get; set; }
        public int SupplierId { get; set; }
        public SupplierViewModel Supplier { get; set; }
        public List<SupplierOrderItemViewModel> Items { get; set; }
        public Price ResultPrice { get; set; }
        public List<SupplierOrderSupplierOrderStatusViewModel> Statuses { get; set; }
    }
}
