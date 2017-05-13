using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    public class SpotTickets
    {

        public decimal Price { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
