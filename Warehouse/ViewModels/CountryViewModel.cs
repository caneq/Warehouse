using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
