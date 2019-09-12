using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecuritySample.Startup))]
namespace SecuritySample
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
