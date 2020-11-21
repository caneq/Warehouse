using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.DataAccessLayer.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ApplicationUserId { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}
