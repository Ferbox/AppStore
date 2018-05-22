using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(identity1.Startup))]
namespace identity1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
