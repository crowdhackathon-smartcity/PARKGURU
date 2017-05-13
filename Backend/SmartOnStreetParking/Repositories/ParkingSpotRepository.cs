using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class ParkingSpotRepository: IParkingSpotRepository
    {

        public List<ParkingSpot> GetByMember(Int64 MemberId)
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                DBContext.Configuration.ProxyCreationEnabled = false;
                var ParkingSpots = DBContext.ParkingSpots.Where(ps => ps.Zone.MemberId == MemberId);
                if (ParkingSpots.Count() == 0)
                {
                    return new List<ParkingSpot>();
                }
                else
                {
                    return DBContext.ParkingSpots.ToList();
                }
            }
        }


        public ParkingSpot Add(ParkingSpot SpotInfo, List<Coordinate> Edges)
        {
            SpotInfo.GeometryEdges = Edges;

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                DBContext.ParkingSpots.Add(SpotInfo);
                DBContext.SaveChanges();
            }
            return SpotInfo;
        }


    }
}
