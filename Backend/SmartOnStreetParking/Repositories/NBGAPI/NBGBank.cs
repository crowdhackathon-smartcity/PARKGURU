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


            return true;

            var uri = "https://nbgdemo.azure-api.net/nodeopenapi/api/banks/{BANK_ID}/transaction-request-types/{TYPE}/transaction-requests?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                //string tmpBody =  string.Format("{ 'description': '{0}', 'challenge_type': '{1}', 'from': { '{account_id': '{2}','bank_id': '{3}'}, 'to': { 'account_id': '{4}', 'bank_id': '{5}'},'value': { 'currency': '{6}','amount': '{7}' } }", "Transaction Desr", "put", FromIBAN, "574b37a801759c440e77c3fe", ToIBAN, "574b37a801759c440e77c3fe", currency, ammount.ToString());
                string tmpBody = string.Empty;// "{'still waiting for NBG support' }";
                //content.Headers.ContentType = new MediaTypeHeaderValue("< your content type, i.e. application/json >");
                content.Headers.ContentType = new MediaTypeHeaderValue(tmpBody);
                response = client.PutAsync(uri, content).Result;
            }

            return true;
        }

    }
}
