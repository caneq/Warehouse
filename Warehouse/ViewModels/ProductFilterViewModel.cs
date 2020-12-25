using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class ProductFilterViewModel
    {
        public IEnumerable<int> Ids { get; set; }
        public string Name { get; set; }
        public int? MaxCount { get; set; }
        public int? MinCount { get; set; }
        public int? UnitId { get; set; }
        public float? MinWeight { get; set; }
        public float? MaxWeight { get; set; }
        public int? ManufactureCountryId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
