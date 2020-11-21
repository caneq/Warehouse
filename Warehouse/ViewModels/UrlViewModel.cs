using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.PresentationLayer.ViewModel
{
    public class UrlViewModel
    {
        public int UrlId { get; set; }
        public int ProductId { get; set; }
        public string UrlString { get; set; }

        public override string ToString()
        {
            return UrlString;
        }
    }
}
