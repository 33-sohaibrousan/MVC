using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_8_2_authrization.Startup))]
namespace MVC_8_2_authrization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
