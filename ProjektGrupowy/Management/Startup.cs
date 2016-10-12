using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Management.Startup))]
namespace Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
