using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FTV_Web.Startup))]
namespace FTV_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
