using System;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Calendar
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
