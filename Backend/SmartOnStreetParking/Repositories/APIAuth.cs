using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class APIAuth : IAPIAuth
    {
        public bool ValidateAPIRequest(string Key, string Secret)
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                var Member = DBContext.Members.Where(u => u.ApiKey == Key && u.ApiSecret == Secret).FirstOrDefault();
                if (Member != null)
                    return true;
                else
                    return false;
            }


        }


        

    }
}
