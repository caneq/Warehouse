using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.ViewModels
{
    public class SupplierOrderItemViewModel
    {
        public int Id { get; set; }
        public int SupplierOrderId { get; set; }
        public Price Price { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
