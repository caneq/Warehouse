using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
    }
}
