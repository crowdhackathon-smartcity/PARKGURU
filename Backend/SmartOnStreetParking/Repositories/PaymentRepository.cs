using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        /// Class Constructor
        /// </summary>
        public PaymentRepository()
        {

        }

        /// <summary>
        /// Get all Payments
        /// </summary>
        public List<Payment> GetAll()
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                DBContext.Configuration.ProxyCreationEnabled = false;
                var payments = DBContext.Payments;
                if (payments.Count() == 0)
                    return new List<Payment>();
                else
                    return DBContext.Payments.Include("Member").Include("ParkingSpot").Include("ParkingSpot.Zone.Member").ToList();
            }
        }
    }
}
