using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Models
{
    public class Product : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public Price Price { get; set; }
        public int ShelfLife { get; set; }
        public int ManufactureCountryId { get; set; }
        public Country ManufactureCountry { get; set; }
        public int CountInStock { get; set; }
        public List<Url> Pictures { get; set; }
    }
}
