using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dweem_monitor.Startup))]
namespace dweem_monitor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
