using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Models
{
    public class OrderStatus : IDataModel
    {
        public int Id { get; set; }
        public string OrderStatusString { get; set; }
        public List<OrderOrderStatus> Orders { get; set; }
        public override string ToString()
        {
            return OrderStatusString;
        }
    }
}
