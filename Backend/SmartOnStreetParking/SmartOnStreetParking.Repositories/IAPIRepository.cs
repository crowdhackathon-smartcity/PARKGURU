using SmartOnStreetParking.Models;
using SmartOnStreetParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public interface IAPIRepository
    {
        List<ParkingSpotResponse> SearchSpots(SearchSpotsRequest SearchSpotsRequest);

        SpotTicketsResponse CalcSpotTickets(CalcTicketsRequest CalcTicketsRequest);

        bool UpdateDummyRecordWithSpatial(long SpotId, List<Coordinate> Edges);

    }
}
