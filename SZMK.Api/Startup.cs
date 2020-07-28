using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SZMK.Api.Startup))]

namespace SZMK.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
