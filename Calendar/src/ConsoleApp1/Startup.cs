using IOC.Service.Calendar;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace ConsoleApp1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Add(IOCServiceConfig.config());
        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
