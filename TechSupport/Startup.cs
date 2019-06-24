using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechSupport.Startup))]
namespace TechSupport
{
    public partial class Startup
    {
        public async void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            await ConfigureRole();
            ConfigurTokenPackages();
            ConfigureChannelPrice();
        }
    }
}
