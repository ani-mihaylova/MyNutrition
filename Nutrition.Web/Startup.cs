using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nutrition.Web.Startup))]
namespace Nutrition.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
