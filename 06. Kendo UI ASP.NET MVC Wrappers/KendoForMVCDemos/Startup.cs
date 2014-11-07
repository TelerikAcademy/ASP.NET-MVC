using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoForMVCDemos.Startup))]
namespace KendoForMVCDemos
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
