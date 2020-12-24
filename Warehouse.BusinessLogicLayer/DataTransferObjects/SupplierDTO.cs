using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PaymentDetails { get; set; }
    }
}
