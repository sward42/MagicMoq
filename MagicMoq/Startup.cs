using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagicMoq.Startup))]
namespace MagicMoq
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
