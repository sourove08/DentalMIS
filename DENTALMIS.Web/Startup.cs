using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DENTALMIS.Web.Startup))]
namespace DENTALMIS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
