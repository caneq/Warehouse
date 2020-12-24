using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.ClassLibrary;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class SupplierOrderItemDTO
    {
        public int Id { get; set; }
        public int SupplierOrderId { get; set; }
        public Price Price { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int Number { get; set; }
    }
}
