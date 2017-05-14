using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class TicketRepository: ITicketRepository
    {
        public List<Ticket> GetByMember(Int64 MemberId)
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                DBContext.Configuration.ProxyCreationEnabled = false;
                var Tickets = DBContext.Tickets.Where(t => t.Zone.MemberId == MemberId);
                if (Tickets.Count() == 0)
                {
                    return new List<Ticket>();
                }
                else
                {
                    return Tickets.ToList();
                }
            }
        }
    }


    public interface ITicketRepository
    {
        List<Ticket> GetByMember(Int64 MemberId);
    }
}
