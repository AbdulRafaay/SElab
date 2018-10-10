using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEP2.Startup))]
namespace SEP2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
