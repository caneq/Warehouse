using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface IDocumentService
    {
        MemoryStream CreateWordInvoice(ShipmentDTO order);
    }
}
