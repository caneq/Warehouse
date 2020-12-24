using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class ClientRequestFilterViewModel
    {
        public int? Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Title { get; set; }
        public bool? Completed { get; set; }
        public DateTime? DateTimeMin { get; set; }
        public DateTime? DateTimeMax { get; set; }
        public int? ClientUnreadMessagesCountMin { get; set; }
        public int? ClientUnreadMessagesCountMax { get; set; }
        public int? ManagersUnreadMessagesCountMin { get; set; }
        public int? ManagersUnreadMessagesCountMax { get; set; }
        public IEnumerable<ClientRequestViewModel> Requests { get; set; }
    }
}
