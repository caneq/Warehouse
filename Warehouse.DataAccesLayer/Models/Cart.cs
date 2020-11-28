using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Models
{
    public class Cart : IDataModel
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}
