using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;

namespace SmartOnStreetParking.Repositories.ParkingSpotImport
{
    /// <summary>
    /// Location class used to keep long & lat
    /// </summary>
    public class ParkingSpotLocation
    {
        public double Latidute { get; set; }
        public double Longitude { get; set; }
    }

    /// <summary>
    /// Helper methods for import Functionality
    /// </summary>
    class ParkingSpotImportHelper
    {
        public ParkingSpotLocation GetLocationFromAddress(string addressString)
        {
            ParkingSpotLocation loc = null;

            try
            {
                loc = new ParkingSpotLocation();

                string requestURI = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}", Uri.EscapeDataString(addressString));
                WebRequest request = WebRequest.Create(requestURI);
                WebResponse response = request.GetResponse();
                XDocument xDoc = XDocument.Load(response.GetResponseStream());

                if (xDoc != null)
                {
                    var result = xDoc.Element("GeocodeResponse").Element("result");
                    var locationElement = result.Element("geometry").Element("location");

                    loc.Latidute = double.Parse(locationElement.Element("lat").Value);
                    loc.Longitude = double.Parse(locationElement.Element("lng").Value);
                }
               

            }
            catch
            {
                loc.Latidute = 0;
                loc.Longitude = 0;
            }

            return loc;
        }

    }

}
