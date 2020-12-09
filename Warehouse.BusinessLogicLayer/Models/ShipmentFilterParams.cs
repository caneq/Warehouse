using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class ShipmentFilterParams
    {
        public int? OrderId { get; set; }
        public string RepicientName { get; set; }
        public string RepicientApplicationUserId { get; set; }
        public string СonveyedName { get; set; }
        public string СonveyedApplicationUserId { get; set; }
        public DateTime MinDateTime { get; set; }
        public DateTime MaxDateTime { get; set; }

        internal Expression<Func<Shipment, bool>> GetLinqExpression()
        {
            return (Shipment s) => (OrderId != null ? s.OrderId == OrderId : true) &&
            (RepicientName != null ? s.RepicientName == RepicientName : true) &&
            (RepicientApplicationUserId != null ? s.RepicientApplicationUserId == RepicientApplicationUserId : true) &&
            (СonveyedName != null ? s.СonveyedName == СonveyedName : true) &&
            (СonveyedApplicationUserId != null ? s.СonveyedApplicationUserId == СonveyedApplicationUserId : true) &&
            (MinDateTime != null ? s.DateTime > MinDateTime : true) &&
            (MaxDateTime != null ? s.DateTime < MaxDateTime : true);
        }

        internal Func<Shipment, bool> GetFuncPredicate()
        {
            return (Shipment s) => (OrderId != null ? s.OrderId == OrderId : true) &&
            (RepicientName != null ? s.RepicientName == RepicientName : true) &&
            (RepicientApplicationUserId != null ? s.RepicientApplicationUserId == RepicientApplicationUserId : true) &&
            (СonveyedName != null ? s.СonveyedName == СonveyedName : true) &&
            (СonveyedApplicationUserId != null ? s.СonveyedApplicationUserId == СonveyedApplicationUserId : true) &&
            (MinDateTime != null ? s.DateTime > MinDateTime : true) &&
            (MaxDateTime != null ? s.DateTime < MaxDateTime : true);
        }
    }
}
