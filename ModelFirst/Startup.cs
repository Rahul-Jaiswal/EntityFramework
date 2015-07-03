using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityFramework.ModelFirst.Startup))]
namespace EntityFramework.ModelFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
