using Owin;
using Microsoft.Owin;

namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             app.UseStaticFiles(); // we need it for Helios

            // Web.API configuration
            ConfigureWebApi(app);
        }
    }
}