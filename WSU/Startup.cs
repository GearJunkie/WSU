using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WSU.Startup))]
namespace WSU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
