using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    /// <summary>
    /// The imput parameter class used to search a map location for available parking spots given a radious in meters
    /// </summary>
    public class SearchSpotsRequest
    {
        /// <summary>
        /// Search location longitude
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// Search location latitude
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Default requested parking duration in order receive pricing info for this period.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Serach radius in meters
        /// </summary>
        public int SearchDistance { get; set; }
        /// <summary>
        /// End user vehicle plate, used to alter pricing when vehicle has active ongoing parking session
        /// </summary>
        public string VehiclePlate { get; set; }
    }
}
