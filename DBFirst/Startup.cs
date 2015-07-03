using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityFramework.DBFirst.Startup))]
namespace EntityFramework.DBFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
