using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSecondCode.Startup))]
namespace MVCSecondCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
