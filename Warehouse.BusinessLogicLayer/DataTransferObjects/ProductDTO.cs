﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public UnitDTO Unit { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public Price Price { get; set; }
        public int? ShelfLife { get; set; }
        public int ManufactureCountryId { get; set; }
        public CountryDTO ManufactureCountry { get; set; }
        public int CountInStock { get; set; }
        public List<UrlDTO> Pictures { get; set; }
    }
}
