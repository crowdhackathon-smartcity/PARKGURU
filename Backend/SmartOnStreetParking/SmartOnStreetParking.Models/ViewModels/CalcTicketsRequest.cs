using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    public class CalcTicketsRequest
    {

        public long SpotId { get; set; }
        public int Duration { get; set; }
    }
}
