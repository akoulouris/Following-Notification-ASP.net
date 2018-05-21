using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CieTrade.Startup))]
namespace CieTrade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
