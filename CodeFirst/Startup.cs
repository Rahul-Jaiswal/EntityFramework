using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityFramework.CodeFirst.Startup))]
namespace EntityFramework.CodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
