using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnQLNS.Startup))]
namespace DoAnQLNS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
