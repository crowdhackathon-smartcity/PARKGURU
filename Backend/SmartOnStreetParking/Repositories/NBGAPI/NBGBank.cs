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
    public  class NBGBank
    {

        public   void GetAll(NBGAuthenticationInfo NBGAuthInfo)
        {
            List<string> tmpBankList = new List<string>();

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

           var uri = "https://nbgdemo.azure-api.net/nodeopenapi/api/banks?" + queryString;
     
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", NBGAuthInfo.OcpApimSubscriptionKey);

            var response = client.GetAsync(uri).Result;
            var data = response.Content.ReadAsStringAsync();

            Console.Write(data);
            //return tmpBankList;
            

        }

        

       
        public Boolean RequestTransaction(NBGAuthenticationInfo NBGAuthInfo, string FromIBAN, string ToIBAN, string currency, double ammount)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Track-ID", NBGAuthInfo.TrackID);
            client.DefaultRequestHeaders.Add("Auth-Provider-Name", NBGAuthInfo.AuthProviderName);
            client.DefaultRequestHeaders.Add("Auth-ID", NBGAuthInfo.AuthID);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", NBGAuthInfo.OcpApimSubscriptionKey);

            var uri = "https://nbgdemo.azure-api.net/nodeopenapi/api/banks/{BANK_ID}/transaction-request-types/{TYPE}/transaction-requests?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                string tmpBody =  string.Format("{ 'description': '{0}', 'challenge_type': '{1}', 'from': { '{2}': '{3}','bank_id': '{4}'}, 'to': { 'account_id': 'string{5}', 'bank_id': 'string{6}'},'value': { 'currency': 'string{7}','amount': { 8} } }", "Transaction Desr", "put", FromIBAN, "574b37a801759c440e77c3fe", ToIBAN, "574b37a801759c440e77c3fe", currency, ammount.ToString());
                content.Headers.ContentType = new MediaTypeHeaderValue("< your content type, i.e. application/json >");
                response = client.PutAsync(uri, content).Result;
            }

            return true;
        }

    }
}
