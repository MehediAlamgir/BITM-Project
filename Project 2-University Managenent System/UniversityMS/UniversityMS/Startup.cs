using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityMS.Startup))]
namespace UniversityMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
