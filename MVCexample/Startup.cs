using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCexample.Startup))]
namespace MVCexample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
