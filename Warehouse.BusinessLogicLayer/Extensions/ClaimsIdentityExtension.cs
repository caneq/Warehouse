using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Warehouse.BusinessLogicLayer.Exceptions;

namespace Warehouse.BusinessLogicLayer.Extensions
{
    public static class ClaimsIdentityExtension
    {
        public static string GetUserId(this ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        return userIdClaim.Value;
                    }
                }
            }
            catch
            {

            }
            return null;
        }
    }
}
