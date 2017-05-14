using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{

    /// <summary>
    /// Input parameter to calculate the cost for a duration in minutes at a parking spot
    /// </summary>
    public class CalcTicketsRequest
    {
        /// <summary>
        /// The parking spot Id
        /// </summary>
        public long SpotId { get; set; }
        /// <summary>
        /// The requested parking duration in minutes
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// End user vehicle plate
        /// </summary>
        public string VehiclePlate { get; set; }
    }
}
