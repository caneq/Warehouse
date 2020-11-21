using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.DataAccesLayer.DataTransferObjects
{
    public class CartProductDTO
    {
        public int CartProductId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
