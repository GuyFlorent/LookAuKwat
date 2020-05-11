using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LookAuKwat.Startup))]
namespace LookAuKwat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
