using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KozmetikTanitimSite.Startup))]
namespace KozmetikTanitimSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
