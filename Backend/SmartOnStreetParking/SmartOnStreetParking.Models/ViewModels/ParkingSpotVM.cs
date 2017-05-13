using SmartOnStreetParking.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    /// <summary>
    /// The parking spot view model
    /// </summary>
    public class ParkingSpotResponse
    {
        /// <summary>
        /// The data provider db Id(City Id)
        /// </summary>
        public long ProviderId { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// City logo
        /// </summary>
        public string ProviderLogo { get; set; }
        /// <summary>
        /// Parking zone fb Id
        /// </summary>
        public long ZoneId { get; set; }
        /// <summary>
        /// Parking zone name
        /// </summary>
        public string ZoneName { get; set; }
        /// <summary>
        /// Parking zone info text
        /// </summary>
        public string ZoneInfo { get; set; }
        /// <summary>
        /// Parkings belong to zone are payable 
        /// </summary>
        public bool ZoneIsPaying { get; set; }
        /// <summary>
        /// Parking color in #XXXXXX format
        /// </summary>
        public string ZoneColor { get; set; }
        /// <summary>
        /// The array of hours and days that parking spot behave as controlled parking spot. Outside array elements payments aren't alloed, probably free paring
        /// </summary>
        public List<ParkingTimeTable> ParkingTimeTable { get; set; }
        /// <summary>
        /// Max allowed parking duration
        /// </summary>
        public int ParkingMaxDuration { get; set; }
        /// <summary>
        /// Parking spot Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Parking spot name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// parking spot info txt
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// Parking spot address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Geometry type enum
        /// </summary>
        public GeometryType GeometryType { get; set; }
        /// <summary>
        /// List of parking spot geometry points
        /// </summary>
        public List<Coordinate> GeometryEdges { get; set; }
        /// <summary>
        /// The current availability state if provided
        /// </summary>
        public AvailabilityState CurrentAvailabilityState { get; set; }
        /// <summary>
        /// Street view json
        /// </summary>
        public string StreetView { get; set; }
        /// <summary>
        /// Tha max parking spot vehicles capacity if provided
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// true if requested search location intersects with parking spot geometry 
        /// </summary>
        public bool AtLocation { get; set; }
        /// <summary>
        /// true if requested search location is nearer than 20 meters of parking spot geometry 
        /// </summary>
        public bool NearLocation { get; set; }
        /// <summary>
        /// Absolute distance between search location and parking spot geometry 
        /// </summary>
        public double LocationDistance { get; set; }
        /// <summary>
        /// Tickets required for 60 minutes parking duration
        /// </summary>
        public SpotTickets Tickets { get; set; }


    }
}
