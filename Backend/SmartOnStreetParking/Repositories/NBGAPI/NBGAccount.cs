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
    class NBGAccount
    {
        public void GetAccountsForBank(string bankID, NBGAuthenticationInfo NBGAuthInfo)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            /*client.DefaultRequestHeaders.Add("Auth-Provider-Name", "fakelogin");
            client.DefaultRequestHeaders.Add("Auth-ID", "123456789");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "135d4237ab144da79fc3d3e577faa971");*/
            client.DefaultRequestHeaders.Add("Track-ID", NBGAuthInfo.TrackID);
            client.DefaultRequestHeaders.Add("Auth-Provider-Name", NBGAuthInfo.AuthProviderName);
            client.DefaultRequestHeaders.Add("Auth-ID", NBGAuthInfo.AuthID);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", NBGAuthInfo.OcpApimSubscriptionKey);

            //var uri = "https://nbgdemo.azure-api.net/nodeopenapi/api/banks/{BANK_ID}/accounts?" + queryString;
            var uri = string.Format("https://nbgdemo.azure-api.net/nodeopenapi/api/banks/{0}/accounts?" + queryString, bankID);

            var response = client.GetAsync(uri).Result;
            var data = response.Content.ReadAsStringAsync();

            Console.Write(data);

        }
    }
}
