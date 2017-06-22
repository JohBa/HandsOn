using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AIT_XamarinCommunityEventService.Startup))]

namespace AIT_XamarinCommunityEventService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}