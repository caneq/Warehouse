using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class OrderFilterParams
    {
        public string UserId { get; set; }
        public int? OrderStatusId { get; set; }
        public string OrderStatusString { get; set; }
        public string LastShippedForUserId { get; set; }
        internal Expression<Func<Order, bool>> GetLinqExpression()
        {
            return (Order p) => (UserId != null ? p.UserId == UserId : true) &&
                (OrderStatusId != null ? p.OrderStatuses.OrderByDescending(s => s.DateTime).FirstOrDefault().OrderStatusId == OrderStatusId : true) &&
                (OrderStatusString != null ? p.OrderStatuses.OrderByDescending(s => s.DateTime).FirstOrDefault().OrderStatus.OrderStatusString == OrderStatusString : true) &&
                (LastShippedForUserId != null ? (p.Shipments.Any() ? p.Shipments.OrderByDescending(s => s.DateTime).FirstOrDefault().RepicientApplicationUserId == LastShippedForUserId : false) : true)
                ;
        }

        internal Func<Order, bool> GetFuncPredicate()
        {
            return (Order p) => (UserId != null ? p.UserId == UserId : true) &&
                (OrderStatusId != null ? p.OrderStatuses.OrderByDescending(s => s.DateTime).FirstOrDefault().OrderStatusId == OrderStatusId : true) &&
                (OrderStatusString != null ? p.OrderStatuses.OrderByDescending(s => s.DateTime).FirstOrDefault().OrderStatus.OrderStatusString == OrderStatusString : true) &&
                (LastShippedForUserId != null ? (p.Shipments.Any() ? p.Shipments.OrderByDescending(s => s.DateTime).FirstOrDefault().RepicientApplicationUserId == LastShippedForUserId : false) : true)
                ;
        }
    }
}
