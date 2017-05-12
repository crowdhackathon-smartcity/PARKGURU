using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    public class SearchSpotsRequest
    {

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public int Duration { get; set; }

        public int SearchDistance { get; set; }
    }
}
