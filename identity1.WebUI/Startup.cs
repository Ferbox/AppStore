using Microsoft.Owin;
using Owin;
using identity1.WebUI.App_Start;

[assembly: OwinStartupAttribute(typeof(identity1.Startup))]
namespace identity1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
