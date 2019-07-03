using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechSupport.Startup))]
namespace TechSupport
{
    public partial class Startup
    {
        public async void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
            await ConfigureRole();
            ConfigurTokenPackages();
            ConfigureChannelPrice();
        }
    }
}
