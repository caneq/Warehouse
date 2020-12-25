using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class ProductFilterParams
    {
        public IEnumerable<int> Ids { get; set; }
        public string Name { get; set; }
        public int? MaxCount { get; set; }
        public int? MinCount { get; set; }
        public int? UnitId { get; set; }
        public float? MinWeight { get; set; }
        public float? MaxWeight { get; set; }
        public int? ManufactureCountryId { get; set; }

        internal Expression<Func<Product, bool>> GetLinqExpression()
        {
            return (Product p) =>
                    (Ids != null && Ids.Any() ? Ids.Contains(p.Id) : true) &&
                    (MaxCount != null ? p.CountInStock < MaxCount : true) &&
                    (MinCount != null ? p.CountInStock > MinCount : true) &&
                    (UnitId != null ? p.UnitId == UnitId : true) &&
                    (MinWeight != null ? p.Weight > MinWeight : true) &&
                    (MaxWeight != null ? p.Weight < MaxWeight : true) &&
                    (ManufactureCountryId != null ? p.ManufactureCountryId == ManufactureCountryId : true) &&
                    (Name != null ? p.Name.Contains(Name, StringComparison.OrdinalIgnoreCase) : true);
        }

        internal Func<Product, bool> GetFuncPredicate()
        {
            return (Product p) =>
                    (Ids != null && Ids.Any() ? Ids.Contains(p.Id) : true) &&
                    (MaxCount != null ? p.CountInStock < MaxCount : true) &&
                    (MinCount != null ? p.CountInStock > MinCount : true) &&
                    (UnitId != null ? p.UnitId == UnitId : true) &&
                    (MinWeight != null ? p.Weight > MinWeight : true) &&
                    (MaxWeight != null ? p.Weight < MaxWeight : true) &&
                    (ManufactureCountryId != null ? p.ManufactureCountryId == ManufactureCountryId : true) &&
                    (Name != null ? p.Name.Contains(Name, StringComparison.OrdinalIgnoreCase) : true);
        }
    }
}
