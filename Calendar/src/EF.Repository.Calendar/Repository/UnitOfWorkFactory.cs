using Microsoft.Data.Entity;
using Repository.Calendar;

namespace EF.Repository.Calendar
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private static IUnitOfWork uow { get; set; }

        public IUnitOfWork Create(ApplicationContextEnum applicationContextEnum)
        {
            switch (applicationContextEnum)
            {
                default:
                case ApplicationContextEnum.InMemory:
                    Create<InMemoryCalendarContext>();
                    break;

                case ApplicationContextEnum.Calendar:
                    Create<CalendarContext>();
                    break;
            }
            
            return uow;
        }

        public IUnitOfWork Get()
        {
            return uow;
        }

        private IUnitOfWork Create<TDbContext>() where TDbContext : DbContext, new()
        {
            if (uow == null || !(((UnitOfWork)uow).Context is TDbContext))
            {
                var unitOfWork = new UnitOfWork();
                unitOfWork.Context = new TDbContext();
                uow = unitOfWork;
            }
            else
                ((UnitOfWork)uow).Nested();

            return uow;
        }
    }
}
