using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class UrlViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UrlString { get; set; }

        public override string ToString()
        {
            return UrlString;
        }
    }
}
