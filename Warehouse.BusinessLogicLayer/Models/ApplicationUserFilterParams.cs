using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class ApplicationUserFilterParams
    {
        public IEnumerable<string> Ids { get; set; }
        public string UserNameContains { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmailContains { get; set; }

        internal Expression<Func<ApplicationUser, bool>> GetLinqExpression()
        {
            return (ApplicationUser u) => (UserName != null ? u.UserName == UserName : true) &&
                (Email != null ? u.Email == Email : true) &&
                (UserNameContains != null ? u.UserName.Contains(UserNameContains, StringComparison.OrdinalIgnoreCase) : true) &&
                (EmailContains != null ? u.Email.Contains(EmailContains, StringComparison.OrdinalIgnoreCase) : true);
                

        }

        internal Func<ApplicationUser, bool> GetFuncPredicate()
        {
            return (ApplicationUser u) => (UserName != null ? u.UserName == UserName : true) &&
                (Email != null ? u.Email == Email : true) &&
                (UserNameContains != null ? u.UserName.Contains(UserNameContains, StringComparison.OrdinalIgnoreCase) : true) &&
                (EmailContains != null ? u.Email.Contains(EmailContains, StringComparison.OrdinalIgnoreCase) : true);
        }
    }
}
