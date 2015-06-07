using Domain.Calendar;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;

namespace EF.Repository.Calendar
{
    public abstract class BaseContext : DbContext
    {
        public IConfiguration Configuration { get; set; }

        public new DbSet<T> Set<T>() where T : Identity
        {
            return base.Set<T>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Visual Studio 2015 | Use the LocalDb 12 instance created by Visual Studio
            Configuration = new Configuration().AddJsonFile("..\\Infra.Calendar\\Config.json");
            optionsBuilder.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>(GameConfig.Config());
        }
    }
}
