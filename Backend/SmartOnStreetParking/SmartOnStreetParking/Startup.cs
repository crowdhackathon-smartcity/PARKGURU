using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartOnStreetParking.Web.Startup))]
namespace SmartOnStreetParking.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
