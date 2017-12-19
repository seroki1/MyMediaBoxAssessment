using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPX_Exercise.Startup))]
namespace ASPX_Exercise
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
