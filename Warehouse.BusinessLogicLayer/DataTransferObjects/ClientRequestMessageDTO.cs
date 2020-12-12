using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class ClientRequestMessageDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ClientRequestId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO User { get; set; }
        public string MessageText { get; set; }
    }
}
