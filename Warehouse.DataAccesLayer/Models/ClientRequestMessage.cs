using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    public class ClientRequestMessage
    {
        public int Id { get; set; }
        public int ClientRequestId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User{ get; set; }
        public string MessageText { get; set; }
    }
}
