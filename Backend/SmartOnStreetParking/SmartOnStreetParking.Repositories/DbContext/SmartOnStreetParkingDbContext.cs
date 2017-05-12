using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking
{

   
    public class SmartOnStreetParkingDbContext : DbContext
    {

        


        public SmartOnStreetParkingDbContext() : base("name=DBSQL")
        {
           
        }

        public static SmartOnStreetParkingDbContext Create()
        {
            return new SmartOnStreetParkingDbContext();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
