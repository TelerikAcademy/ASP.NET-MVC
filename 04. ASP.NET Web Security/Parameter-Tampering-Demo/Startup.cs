using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parameter_Tampering_Demo.Startup))]

namespace Parameter_Tampering_Demo
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
