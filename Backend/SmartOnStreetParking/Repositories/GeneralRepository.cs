using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        public List<dynamic> GetZonesLight(Int64 MemberId)
        {
            List<dynamic> RetVal = new List<dynamic>();
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                var Result = (from v in DBContext.Zones
                              where v.MemberId == MemberId
                              select new
                              {
                                  Id = v.Id,
                                  Name = v.Name
                              }).ToList();


                if (Result != null)
                {
                    Result.ForEach((x) =>
                    {
                        dynamic obj = new ExpandoObject();
                        obj.Id = x.Id;
                        obj.Name = x.Name;
                        RetVal.Add(obj);
                    });
                }
            }
            return RetVal;
        }
    }
}
