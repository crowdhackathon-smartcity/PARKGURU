using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models
{
    public class ParkingTimeTable
    {

        /// <summary>
        /// The days of the week enuam
        /// </summary>
        public DayOfWeek Days { get; set; }
        /// <summary>
        /// Start timespan
        /// </summary>
        public TimeSpan Start { get; set; }
        /// <summary>
        /// End timespan
        /// </summary>
        public TimeSpan End { get; set; }


    }
}
