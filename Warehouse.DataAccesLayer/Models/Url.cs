using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Models
{
    public class Url : IDataModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UrlString { get; set; }
        public override string ToString()
        {
            return UrlString;
        }
    }
}
