using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class ClientRequestDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }
        public string Title { get; set; }
        public List<ClientRequestMessageDTO> Messages { get; set; }
        public bool Completed { get; set; }
        public int ClientUnreadMessagesCount { get; set; }
        public int ManagersUnreadMessagesCount { get; set; }
    }
}
