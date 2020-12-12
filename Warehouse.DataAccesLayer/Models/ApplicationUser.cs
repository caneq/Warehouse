using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccessLayer.Interfaces;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.DataAccessLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
        public List<Shipment> RepicientShipments { get; set; }
        public List<Shipment> ConveyedShipments { get; set; }
        public List<ClientRequest> ClientRequests { get; set; }
    }
}
