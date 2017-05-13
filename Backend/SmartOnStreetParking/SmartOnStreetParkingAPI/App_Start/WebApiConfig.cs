using SmartOnStreetParking.API.AuthorizeAPIRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmartOnStreetParkingAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {



            // Web API configuration and services

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            GlobalConfiguration.Configuration.MessageHandlers.Add(new BasicAuthenticationHandler());
            //config.Filters.Add(new BasicAuthenticationAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);


        }
    }
}
