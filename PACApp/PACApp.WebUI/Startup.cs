using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PACApp.WebUI.Startup))]
namespace PACApp.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
