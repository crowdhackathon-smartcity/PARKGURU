using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    /// <summary>
    /// Class used to describe parking spot payment requirements(tickets)
    /// </summary>
    public class SpotTickets
    {
        /// <summary>
        /// Total price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// List of amount per duration
        /// </summary>
        public List<Ticket> Tickets { get; set; }
    }
}
