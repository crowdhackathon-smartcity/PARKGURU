using SmartOnStreetParking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Web;

namespace SmartOnStreetParking.API.AuthorizeAPIRequest
{





    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute

    {


        private Dictionary<string, string> ParseRequestHeaders(System.Web.Http.Controllers.HttpActionContext actionContext)

        {
            
            Dictionary<string, string> credentials = new Dictionary<string, string>();

            var httpRequestHeader = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();

            httpRequestHeader = Encoding.UTF8.GetString(Convert.FromBase64String(httpRequestHeader.Substring("Basic".Length)));

            string[] httpRequestHeaderValues = httpRequestHeader.Split(':');

            string APIKey = httpRequestHeaderValues[0];

            string APISecret = httpRequestHeaderValues[1];

            credentials.Add("APIKey", APIKey);

            credentials.Add("APISecret", APISecret);

            return credentials;

        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)

        {

            try

            {

                if (actionContext.Request.Headers.Authorization == null)

                {

                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

                }

                else

                {

                    Dictionary<string, string> credentials = ParseRequestHeaders(actionContext);
                    IAPIAuth AuthRepo = new APIAuth();
                    if (AuthRepo.ValidateAPIRequest(credentials["APIKey"], credentials["APISecret"]))

                        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);

                    else

                        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

                }

            }

            catch

            {

                actionContext.Response = new System.Net.Http.HttpResponseMessage

(System.Net.HttpStatusCode.InternalServerError);

            }

        }

    }

}