using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSRF_Example.Startup))]

namespace CSRF_Example
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
