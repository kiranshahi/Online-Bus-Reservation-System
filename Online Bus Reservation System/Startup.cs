using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Bus_Reservation_System.Startup))]
namespace Online_Bus_Reservation_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
