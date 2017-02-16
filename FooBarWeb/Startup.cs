using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FooBarWeb.Startup))]
namespace FooBarWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
