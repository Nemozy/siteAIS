using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kkgamesProj.Startup))]
namespace kkgamesProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
