using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        /// <summary>
        /// Get Number of Zones from the database.
        /// </summary>
        /// /// <param name="MemberID">The Id of the Member.</param>
        public int GetZonesCount()
        {
            int TotalZones = 0;
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                try
                {
                    //TotalZones = DBContext.Zones.Where(u => u.MemberId == MemberID).Count();
                    TotalZones = DBContext.Zones.Count();

                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            return TotalZones;
        }
    }
}
