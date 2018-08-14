using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDemo.Web.Startup))]
namespace MVCDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
