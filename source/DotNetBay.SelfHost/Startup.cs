using System;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DotNetBay.SelfHost.Startup))]

namespace DotNetBay.SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var httpConfiguration = new HttpConfiguration();
            
            httpConfiguration.MapHttpAttributeRoutes();

            app.UseWebApi(httpConfiguration);
        }
    }
}
