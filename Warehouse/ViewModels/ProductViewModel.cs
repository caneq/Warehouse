﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public UnitViewModel Unit { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public Price Price { get; set; }
        public int ShelfLife { get; set; }
        public int ManufactureCountryId { get; set; }
        public CountryViewModel ManufactureCountry { get; set; }
        public int CountInStock { get; set; }
        public List<UrlViewModel> Pictures { get; set; }
    }
}
