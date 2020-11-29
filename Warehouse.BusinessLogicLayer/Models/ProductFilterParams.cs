using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class ProductFilterParams
    {
        public string Name { get; set; }
        public int? MaxCount { get; set; }
        public int? MinCount { get; set; }
        public UnitDTO Unit { get; set; }
        public float? MinWeight { get; set; }
        public float? MaxWeight { get; set; }
        public int? ManufactureCountryId { get; set; }

        internal Expression<Func<Product, bool>> GetLinqExpression()
        {
            return (Product p) => p.CountInStock > (MinCount ?? int.MinValue) &&
                p.CountInStock < (MaxCount ?? int.MaxValue) &&
                p.Weight < (MaxWeight ?? float.MaxValue);
        }

        internal Func<Product, bool> GetFuncPredicate()
        {
            return (Product p) => p.CountInStock > (MinCount ?? int.MinValue) &&
                p.CountInStock < (MaxCount ?? int.MaxValue) &&
                p.Weight < (MaxWeight ?? float.MaxValue);
        }
    }
}
