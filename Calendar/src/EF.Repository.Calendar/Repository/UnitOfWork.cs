using Microsoft.Data.Entity;
using Repository.Calendar;
using System.Threading;
using System.Threading.Tasks;   

namespace EF.Repository.Calendar
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }
        private int n = 0;

        public void Nested()
        {
            n++;
        }
        public void Dispose()
        {
            if (doAction())
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
            else
                n--;
        }

        public void SaveChanges()
        {
            if(doAction())
                Context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return SaveChangesAsync(CancellationToken.None);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            if(doAction())
                return Context.SaveChangesAsync(cancellationToken);

            return null;
        }

        private bool doAction()
        {
            if (n == 0)
                return true;
            else
                return false;
        }
    }
}
