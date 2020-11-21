using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.DataAccesLayer.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitString { get; set; }

        public override string ToString()
        {
            return UnitString;
        }
    }
}
