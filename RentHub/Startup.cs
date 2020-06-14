using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentHub.Startup))]
namespace RentHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
