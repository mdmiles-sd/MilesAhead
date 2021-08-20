using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MilesAhead.Startup))]
namespace MilesAhead
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
