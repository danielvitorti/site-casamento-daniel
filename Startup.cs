using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(casamento.Startup))]
namespace casamento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
