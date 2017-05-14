using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace SmartOnStreetParking.Repositories.NBGAPI
{
    class NBGCustomer
    {

        public void GetCustomersForBankID(string bankID, NBGAuthenticationInfo NBGAuthInfo)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            
            client.DefaultRequestHeaders.Add("Auth-Provider-Name", NBGAuthInfo.AuthProviderName);
            client.DefaultRequestHeaders.Add("Auth-ID", NBGAuthInfo.AuthID);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", NBGAuthInfo.OcpApimSubscriptionKey);


            //var uri = "https://nbgdemo.azure-api.net/nodeopenapi/api/banks/{BANK_ID}/customers?" + queryString;
            var uri = string.Format("https://nbgdemo.azure-api.net/nodeopenapi/api/banks/{0}/customers?" + queryString, bankID);

            var response = client.GetAsync(uri).Result;
            var data = response.Content.ReadAsStringAsync();

            Console.Write(data);

        }
    }
}
