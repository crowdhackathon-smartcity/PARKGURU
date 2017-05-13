using SmartOnStreetParking.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    public class ParkingSpotResponse
    {
        public long ProviderId { get; set; }
        public string ProviderName { get; set; }

        public string ProviderLogo { get; set; }

        public long ZoneId { get; set; }

        public string ZoneName { get; set; }

        public string ZoneInfo { get; set; }

        public bool ZoneIsPaying { get; set; }

        public string ZoneColor { get; set; }

        public List<ParkingTimeTable> ParkingTimeTable { get; set; }

        public int ParkingMaxDuration { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public string Address { get; set; }

        public GeometryType GeometryType { get; set; }

        public List<Coordinate> GeometryEdges { get; set; }

        public AvailabilityState CurrentAvailabilityState { get; set; }

        public string StreetView { get; set; }

        public int Capacity { get; set; }

        public bool AtLocation { get; set; }

        public bool NearLocation { get; set; }

        public double LocationDistance { get; set; }

        public SpotTicketsResponse Tickets { get; set; }


    }
}
