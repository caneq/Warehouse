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
        public string Body { get; set; }
        public bool? Completed { get; set; }

        internal Expression<Func<ClientRequest, bool>> GetLinqExpression()
        {
            return (ClientRequest c) => 
                (Id != null ? c.Id == Id : true) &&
                (ApplicationUserId != null ? c.ApplicationUserId == ApplicationUserId : true) &&
                (Title != null ? c.Title == Title : true) &&
                (Completed != null ? c.Completed == Completed : true);
        }

        internal Func<ClientRequest, bool> GetFuncPredicate()
        {
            return (ClientRequest c) =>
                (Id != null ? c.Id == Id : true) &&
                (ApplicationUserId != null ? c.ApplicationUserId == ApplicationUserId : true) &&
                (Title != null ? c.Title == Title : true) &&
                (Body != null ? c.Body == Body : true) &&
                (Answered != null ? c.Answered == Answered : true);
        }
    }
}
