using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Models
{
    class ProductFilterParams
    {
        public string Name { get; set; }
        public int MaxCount { get; set; }
        public int MinCount { get; set; }
        public UnitDTO Unit { get; set; }
        public float MinWeight { get; set; }
        public float MaxWeight { get; set; }
        public int ManufactureCountryId { get; set; }
    }
}
