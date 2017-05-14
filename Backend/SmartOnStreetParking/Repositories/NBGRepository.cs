using SmartOnStreetParking.Repositories.NBGClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class NBGRepository : INBGRepository
    {
        public void GetBanks()
        {
            //Set default values for demo usage
            //TODO : Remove this initialization code
            NBGAPI.NBGAuthenticationInfo NBGAuthInfo = new NBGAPI.NBGAuthenticationInfo();

            NBGAuthInfo.AuthProviderName = "fakelogin";
            NBGAuthInfo.AuthID = "123456789";
            NBGAuthInfo.OcpApimSubscriptionKey = "135d4237ab144da79fc3d3e577faa971";

            NBGHandler NBGObject = new NBGHandler(NBGAuthInfo);
            NBGObject.GetAllBanks();
        }

        public Boolean MakeTransaction(string NBGAuthID, string NBGAuthToken, string FromIBAN, string ToIBAN, string currency, double ammount)
        {
            //Set default values for demo usage
            //TODO : Remove this initialization code
            NBGAPI.NBGAuthenticationInfo NBGAuthInfo = new NBGAPI.NBGAuthenticationInfo();

            NBGAuthInfo.AuthProviderName = "fakelogin";
            NBGAuthInfo.AuthID = NBGAuthID;// "123456789";
            NBGAuthInfo.OcpApimSubscriptionKey = NBGAuthToken;// "135d4237ab144da79fc3d3e577faa971";

            NBGHandler NBGObject = new NBGHandler(NBGAuthInfo);
            NBGObject.requestTransaction();
            return true;

        }
    }
}
