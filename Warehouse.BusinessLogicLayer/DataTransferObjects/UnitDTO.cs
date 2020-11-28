using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string UnitString { get; set; }

        public override string ToString()
        {
            return UnitString;
        }
    }
}
