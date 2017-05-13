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

        SpotTickets CalcSpotTickets(CalcTicketsRequest CalcTicketsRequest);

        bool UpdateDummyRecordWithSpatial(long SpotId, List<Coordinate> Edges);

        Payment Pay(PayRequest PayRequest, string ApiKey);

    }
}
