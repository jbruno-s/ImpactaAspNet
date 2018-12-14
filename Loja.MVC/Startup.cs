using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Loja.MVC.Startup))]
namespace Loja.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
