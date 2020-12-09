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
        public OrderStatusDTO OrderStatus { get; set; }
        public string LastShippedForUserId { get; set; }
        internal Expression<Func<Order, bool>> GetLinqExpression()
        {
            return (Order p) => (UserId != null ? p.UserId == UserId : true) &&
                (OrderStatus != null ? p.OrderStatuses.OrderByDescending(s => s.DateTime).FirstOrDefault().OrderStatusId == OrderStatus.Id : true) &&
                (LastShippedForUserId != null ? (p.Shipments.Any() ? p.Shipments.OrderByDescending(s => s.DateTime).FirstOrDefault().RepicientApplicationUserId == LastShippedForUserId : false) : true)
                ;
        }

        internal Func<Order, bool> GetFuncPredicate()
        {
            return (Order p) => (UserId != null ? p.UserId == UserId : true) &&
                (OrderStatus != null ? p.OrderStatuses.OrderByDescending(s => s.DateTime).FirstOrDefault().OrderStatusId == OrderStatus.Id : true) &&
                (LastShippedForUserId != null ? (p.Shipments.Any() ? p.Shipments.OrderByDescending(s => s.DateTime).FirstOrDefault().RepicientApplicationUserId == LastShippedForUserId : false) : true)
                ;
        }
    }
}
