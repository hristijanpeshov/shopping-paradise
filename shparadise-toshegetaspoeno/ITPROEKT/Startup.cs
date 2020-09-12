using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITPROEKT.Startup))]
namespace ITPROEKT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
