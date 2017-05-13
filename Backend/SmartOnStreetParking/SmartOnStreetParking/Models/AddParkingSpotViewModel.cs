using SmartOnStreetParking.Models;
using System;
using System.Globalization;
using System.Linq;

namespace SmartOnStreetParking.Web.Models
{
    public class AddParkingSpotViewModel : ParkingSpot
    {
        public string StringEdges { get; set; }




        public string EdgesToJson()
        {
            var coordString = "";
            if (GeometryEdges != null && GeometryEdges.Count > 0)
            {
                foreach (var item in GeometryEdges)
                {
                    coordString = coordString + string.Format("{{\"lng\":{0} ,\"lat\": {1}}},", item.Longitude.ToString(CultureInfo.InvariantCulture), item.Latitude.ToString(CultureInfo.InvariantCulture));
                }
                coordString = "[" + coordString.Substring(0, coordString.Length - 1) + "]";
            }
            return coordString;
        }
    }
}