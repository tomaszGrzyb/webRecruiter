using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRecruiter.Startup))]
namespace WebRecruiter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
