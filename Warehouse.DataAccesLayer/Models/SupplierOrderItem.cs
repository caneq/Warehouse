using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.ClassLibrary;

namespace Warehouse.DataAccessLayer.Models
{
    public class SupplierOrderItem
    {
        public int Id { get; set; }
        public int SupplierOrderId { get; set; }
        public Price Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Number { get; set; }
    }
}
