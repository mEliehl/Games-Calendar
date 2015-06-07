using Domain.Calendar;
using Microsoft.Data.Entity;
using Repository.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EF.Repository.Calendar
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Identity
    {
        protected DbContext Context{ get
            {
                var uow = (UnitOfWork)new UnitOfWorkFactory().Get();
                if (uow == null || uow.Context == null)
                    throw new ContextNotCreatedOrNullException();
                return uow.Context;
            }
        }

        public void Add(T entity)
        {
            Context.Add(entity);
        }

        public void AddRange(IList<T> entities)
        {
            Context.AddRange(entities);
        }

        public T GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(f => f.Id == id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return Context.Set<T>().FirstOrDefaultAsync(f => f.Id == id);
        }

        public IList<T> Get(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>()
                .Where(exp)
                .ToList();
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>()
                .Where(exp)
                .ToListAsync();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IList<T> entities)
        {
            Context.UpdateRange(entities);
        }

        public void Remove(int id)
        {
            var entity = this.GetById(id);
            if(entity != null)
                Remove(entity);
        }

        public void Remove(T entity)
        {
            Context.Remove(entity);
        }

        public void RemoveRange(IList<T> entities)
        {
            Context.RemoveRange(entities);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().AnyAsync(exp);
        }
    }
}
