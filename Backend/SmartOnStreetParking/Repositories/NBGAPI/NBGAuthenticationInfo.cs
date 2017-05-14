using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories.NBGAPI
{
    /// <summary>
    /// Classinitialized with all Aythentication info needed by the API
    /// </summary>
    public class NBGAuthenticationInfo
    {
        
        /// <summary>
        /// The external reference Id
        /// </summary>        
        public string TrackID { get; set; }

        public string AuthProviderName { get; set; }

        public string AuthID { get; set; }

        /// <summary>
        /// User Token
        /// </summary>
        public string OcpApimSubscriptionKey { get; set; }

    }
}
