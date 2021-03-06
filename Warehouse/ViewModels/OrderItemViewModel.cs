﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }
        public Price Price { get; set; }
    }
}
