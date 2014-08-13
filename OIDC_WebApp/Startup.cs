using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OIDC_WebApp.Startup))]
namespace OIDC_WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
