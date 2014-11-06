using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caching.MVC.Startup))]

namespace Caching.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
