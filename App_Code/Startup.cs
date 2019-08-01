using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDb.Startup))]
namespace WebDb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
