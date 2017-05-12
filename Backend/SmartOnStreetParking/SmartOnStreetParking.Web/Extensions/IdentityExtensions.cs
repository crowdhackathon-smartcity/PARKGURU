using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace SmartOnStreetParking.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetProperty(this IIdentity identity, string PropertyName)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(PropertyName);
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : "0";
        }
    }

}