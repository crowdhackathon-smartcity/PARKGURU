using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    public class PayRequest
    {

        public long SpotId { get; set; }
        public SpotTickets SpotTickets { get; set; }
        public string VehiclePlate { get; set; }
    }
}
