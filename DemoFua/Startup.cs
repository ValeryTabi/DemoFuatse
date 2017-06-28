using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoFua.Startup))]
namespace DemoFua
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
