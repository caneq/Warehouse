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
        public string Body { get; set; }
    }
}
