using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class UnitViewModel
    {
        public int UnitId { get; set; }
        public string UnitString { get; set; }

        public override string ToString()
        {
            return UnitString;
        }
    }
}
