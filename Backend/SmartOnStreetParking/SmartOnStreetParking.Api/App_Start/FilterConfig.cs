using SmartOnStreetParking.API.AuthorizeAPIRequest;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace SmartOnStreetParkingAPI
{
    public class FilterConfig
    {


        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            //filters.Add(new BasicAuthenticationAttribute());
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
        }
    }
}
