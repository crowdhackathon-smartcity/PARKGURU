using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartOnStreetParking.Repositories
{
    public interface IParkingSpotRepository
    {
        List<ParkingSpot> GetByMember(Int64 MemberId);

        ParkingSpot Add(ParkingSpot SpotInfo, List<Coordinate> Edges);
    }
}
