using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int ApplicationUserViewModelId { get; set; }
        public List<CartProductViewModel> CartProducts { get; set; }
    }
}
