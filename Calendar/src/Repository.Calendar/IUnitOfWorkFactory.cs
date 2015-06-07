namespace Repository.Calendar
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(ApplicationContextEnum applicationContextEnum);
        IUnitOfWork Get();
    }
}
