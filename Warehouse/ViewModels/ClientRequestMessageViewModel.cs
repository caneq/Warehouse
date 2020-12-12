using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class ClientRequestMessageViewModel
    {
        public int Id { get; set; }
        public int ClientRequestId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserViewModel User { get; set; }
        public string MessageText { get; set; }
    }
}
