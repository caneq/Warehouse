using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.PresentationLayer.ViewModel
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public int ApplicationUserViewModelId { get; set; }
        public List<CartProductViewModel> CartProducts { get; set; }
    }
}
