using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelerikAcademy.ForumSystem.Web.Startup))]
namespace TelerikAcademy.ForumSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
