using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Interfaces;

namespace Warehouse.DataAccessLayer.Models
{
    public class Country : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
