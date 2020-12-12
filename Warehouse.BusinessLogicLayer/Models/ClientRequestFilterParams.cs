using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class ClientRequestFilterParams
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

        internal Expression<Func<ClientRequest, bool>> GetLinqExpression()
        {
            return (ClientRequest c) => 
                (Id != null ? c.Id == Id : true) &&
                (ApplicationUserId != null ? c.ApplicationUserId == ApplicationUserId : true) &&
                (Title != null ? c.Title == Title : true) &&
                (Completed != null ? c.Completed == Completed : true) &&
                (ClientUnreadMessagesCountMin != null ? c.ClientUnreadMessagesCount < ClientUnreadMessagesCountMin : true) &&
                (ClientUnreadMessagesCountMax != null ? c.ClientUnreadMessagesCount > ClientUnreadMessagesCountMax : true) &&
                (DateTimeMin != null ? c.DateTime > DateTimeMin : true) &&
                (DateTimeMax != null ? c.DateTime < DateTimeMax : true);
        }

        internal Func<ClientRequest, bool> GetFuncPredicate()
        {
            return (ClientRequest c) =>
                (Id != null ? c.Id == Id : true) &&
                (ApplicationUserId != null ? c.ApplicationUserId == ApplicationUserId : true) &&
                (Title != null ? c.Title == Title : true) &&
                (Completed != null ? c.Completed == Completed : true) &&
                (ClientUnreadMessagesCountMin != null ? c.ClientUnreadMessagesCount < ClientUnreadMessagesCountMin : true) &&
                (ClientUnreadMessagesCountMax != null ? c.ClientUnreadMessagesCount > ClientUnreadMessagesCountMax : true) &&
                (DateTimeMin != null ? c.DateTime > DateTimeMin : true) &&
                (DateTimeMax != null ? c.DateTime < DateTimeMax : true);
        }
    }
}
