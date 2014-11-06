using Microsoft.Owin;

[assembly: OwinStartup(typeof(Caching.MVC.Startup))]

namespace Caching.MVC
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
