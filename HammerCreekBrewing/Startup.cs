using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HammerCreekBrewing.Startup))]
namespace HammerCreekBrewing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
