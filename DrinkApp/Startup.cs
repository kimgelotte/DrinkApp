using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrinkApp.Startup))]
namespace DrinkApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // init
            ConfigureAuth(app);
        }
    }
}
