using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AGRISmartPro.Startup))]
namespace AGRISmartPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
