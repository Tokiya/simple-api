using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Threading;

[assembly: OwinStartup(typeof(People.Api.Startup))]

namespace People.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();
          
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            start();
        }

        void start() {
            new Task(() => {
                while (true) {
                    Thread.Sleep(5000);
                }
            }).Start();
        }
    }
}
