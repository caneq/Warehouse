using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces.Generic;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    interface IOrderService : IGenericService<OrderDTO>
    {
    }
}
