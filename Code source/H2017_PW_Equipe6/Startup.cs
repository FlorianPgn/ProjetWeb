using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(H2017_PW_Equipe6.Startup))]
namespace H2017_PW_Equipe6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
