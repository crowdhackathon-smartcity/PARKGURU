using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    /// <summary>
    /// Input parameter class for the payment of a parking spot
    /// </summary>
    public class PayRequest
    {
        /// <summary>
        /// Parking spot Id
        /// </summary>
        public long SpotId { get; set; }
        /// <summary>
        /// Parking spot payment requirements(tickets)
        /// </summary>
        public SpotTickets SpotTickets { get; set; }
        /// <summary>
        /// End user vehicle plate
        /// </summary>
        public string VehiclePlate { get; set; }
        /// <summary>
        /// Developer/service provider APIkey
        /// </summary>
        public string APIkey { get; set; }
    }
}
