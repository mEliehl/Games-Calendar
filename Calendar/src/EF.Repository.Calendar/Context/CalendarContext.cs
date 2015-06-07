using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;

namespace EF.Repository.Calendar
{
    public class CalendarContext : BaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Visual Studio 2015 | Use the LocalDb 12 instance created by Visual Studio
            Configuration = new Configuration().AddJsonFile("..\\Infra.Calendar\\Config.json");
            optionsBuilder.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString"));
        }

        
    }
}
