using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechSupport.Startup))]
namespace TechSupport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
