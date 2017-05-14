using SmartOnStreetParking.Repositories.NBGAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories.NBGClasses
{
    class NBGHandler
    {


        /// <summary>
        /// The external reference Id
        /// </summary>        
        public NBGAuthenticationInfo AuthInfo { get; set; }


        /// <summary>
        /// Constructor used to pass the initial imported xml values auth info
        /// </summary>
        /// <param name="NBGAuthInfo"></param>
        public NBGHandler(NBGAuthenticationInfo NBGAuthInfo)
        {
            AuthInfo = NBGAuthInfo;
        }

        public void GetAllBanks()
        {
          NBGBank  tmpBank = new NBGBank();
            tmpBank.GetAll(AuthInfo);
       }

        public void GetCustomerForBank(string bankID)
        {
            //bankID = "5710bba5d42604e4072d1e72
            NBGCustomer objCustomer = new NBGCustomer();
            objCustomer.GetCustomersForBankID(bankID, AuthInfo);
        }

        public Boolean requestTransaction(string FromIBAN, string ToIBAN, string currency, double ammount)
        {
            //bankID = "5710bba5d42604e4072d1e72
            NBGBank objBank = new NBGBank();
            return objBank.RequestTransaction(AuthInfo, FromIBAN, ToIBAN, currency, ammount);

        }

    }
}
