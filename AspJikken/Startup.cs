using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspJikken.Startup))]
namespace AspJikken
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
