using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class SupplierOrderFilterParams
    {
        public int? Id { get; set; }
        public DateTime? DateTimeMin { get; set; }
        public DateTime? DateTimeMax { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public int? SupplierId { get; set; }

        internal Expression<Func<SupplierOrder, bool>> GetLinqExpression()
        {
            return (SupplierOrder p) => (UserId != null ? p.UserId == UserId : true) &&
                (Status != null ? (p.Statuses.FirstOrDefault() != null ? p.Statuses.FirstOrDefault().SupplierOrderStatus.String == Status : false) : true) &&
                (Id != null ? p.Id == Id : true) &&
                (SupplierId != null ? p.SupplierId == SupplierId : true) &&
                (DateTimeMin != null ? p.DateTime > DateTimeMin : true) &&
                (DateTimeMax != null ? p.DateTime < DateTimeMax : true);
        }

        internal Func<SupplierOrder, bool> GetFuncPredicate()
        {
            return (SupplierOrder p) => (UserId != null ? p.UserId == UserId : true) &&
                (Status != null ? (p.Statuses.FirstOrDefault() != null ? p.Statuses.FirstOrDefault().SupplierOrderStatus.String == Status : false) : true) &&
                (Id != null ? p.Id == Id : true) &&
                (SupplierId != null ? p.SupplierId == SupplierId : true) &&
                (DateTimeMin != null ? p.DateTime > DateTimeMin : true) &&
                (DateTimeMax != null ? p.DateTime < DateTimeMax : true);
        }
    }
}
