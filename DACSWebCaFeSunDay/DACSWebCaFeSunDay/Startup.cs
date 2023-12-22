using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DACSWebCaFeSunDay.Startup))]
namespace DACSWebCaFeSunDay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
