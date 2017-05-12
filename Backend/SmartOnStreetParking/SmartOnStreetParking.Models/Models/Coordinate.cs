using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models
{
    public class Coordinate
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }



        public Coordinate() { }

        public Coordinate(double pLatitude,double pLongitude )
        {
            Longitude = pLongitude;
            Latitude = pLatitude;
        }


    }
}
