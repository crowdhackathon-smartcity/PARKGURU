using SmartOnStreetParking.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class APIAuth : IAPIAuth
    {
        public long ValidateAPIRequest(string Key, string Secret)
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                var Member = DBContext.Members.Where(u => u.ApiKey == Key && u.ApiSecret == Secret).FirstOrDefault();
                if (Member != null)
                {
                    var identity = new BasicAuthenticationIdentity(Key, Secret);
                    var principal = new GenericPrincipal(identity, null);

                    Thread.CurrentPrincipal = principal;
                    return Member.Id;

                }
                    
                else
                    return 0;
            }


        }


        

    }
}
