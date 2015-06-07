using IOC.Infra.Calendar;
using IOC.Repository.Calendar;
using IOC.Service.Calendar;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace WebApi.Calendar
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Add(IOCRepositoryConfig.config());
            services.Add(IOCServiceConfig.config());
            services.Add(IOCInfraConfig.config());
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
