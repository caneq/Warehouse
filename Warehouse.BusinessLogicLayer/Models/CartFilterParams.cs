using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Warehouse.DataAccessLayer.Models;

namespace Warehouse.BusinessLogicLayer.Models
{
    public class CartFilterParams
    {
        public string ApplicationUserId { get; set; }

        internal Expression<Func<Cart, bool>> GetLinqExpression()
        {
            return (Cart c) => c.ApplicationUserId == ApplicationUserId;
        }

        internal Func<Cart, bool> GetFuncPredicate()
        {
            return (Cart c) => c.ApplicationUserId == ApplicationUserId;
        }
    }
}
