using Repository.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Calendar;
using System.Linq.Expressions;

namespace Test.Service.Fakes
{
    public class FakeGameRepository : IGameRepository
    {
        public bool AnyReturn { get; set; }

        public void Add(Game entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IList<Game> entities)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<Game, bool>> exp)
        {
            return AnyReturn;
        }

        public Task<bool> AnyAsync(Expression<Func<Game, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IList<Game> Get(Expression<Func<Game, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> GetAsync(Expression<Func<Game, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Game GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Game entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IList<Game> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Game entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IList<Game> entities)
        {
            throw new NotImplementedException();
        }
    }
}
