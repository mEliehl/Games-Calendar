using Microsoft.Data.Entity;

namespace EF.Repository.Calendar
{
    public class InMemoryCalendarContext : BaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryStore();
        }
    }
}
