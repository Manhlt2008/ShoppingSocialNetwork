using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingSocial.Startup))]
namespace ShoppingSocial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
