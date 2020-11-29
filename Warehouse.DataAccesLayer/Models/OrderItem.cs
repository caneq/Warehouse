using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Models
{
    public class OrderItem : IDataModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Price Price { get; set; }
    }
}
