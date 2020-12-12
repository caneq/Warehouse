using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.ViewModels
{
    public class ClientRequestViewModel
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public string Title { get; set; }
        public List<ClientRequestMessageViewModel> Messages { get; set; }
        public bool Сompleted { get; set; }
        public int ClientUnreadMessagesCount { get; set; }
        public int ManagersUnreadMessagesCount { get; set; }
    }
}
