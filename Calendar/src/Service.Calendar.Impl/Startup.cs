using IOC.Repository.Calendar;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;


namespace Service.Calendar.Impl
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Add(IOCRepositoryConfig.config());
        }

        public void Configure(IApplicationBuilder app)
        {
            
        }
    }
}
