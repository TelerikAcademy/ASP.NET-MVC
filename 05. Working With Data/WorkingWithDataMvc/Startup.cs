using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkingWithDataMvc.Startup))]
namespace WorkingWithDataMvc
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
