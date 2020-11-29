using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductId { get; set; }
        public Price Price { get; set; }
    }
}
