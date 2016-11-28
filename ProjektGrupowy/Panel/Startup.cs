using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Panel.Startup))]
namespace Panel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
