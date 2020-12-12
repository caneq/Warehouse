using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    public class ClientRequest
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Title { get; set; }
        public List<ClientRequestMessage> Messages { get; set; }
        public bool Сompleted { get; set; }
        public int ClientUnreadMessagesCount { get; set; }
        public int ManagersUnreadMessagesCount { get; set; }
    }
}
