using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class CartDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public List<CartProductDTO> CartProducts { get; set; }
    }
}
