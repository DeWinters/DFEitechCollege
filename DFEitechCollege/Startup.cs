using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DFEitechCollege.Startup))]
namespace DFEitechCollege
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
