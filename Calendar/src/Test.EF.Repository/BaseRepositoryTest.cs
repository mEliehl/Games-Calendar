using Domain.Calendar;
using EF.Repository.Calendar;
using Repository.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.EF.Repository
{
    public abstract class BaseRepositoryTest<TReposytory, T>
        where TReposytory : IBaseRepository<T>
        where T : Identity
    {
        readonly IBaseRepository<T> repository;
        protected int invalidId;

        public BaseRepositoryTest(IBaseRepository<T> repository)
        {
            this.repository = repository;
            invalidId = -1;
        }

        public abstract T CreateTestObject();
        public abstract IList<T> CreateTestList();
        public abstract T EditTestObeject(T entity);

        [Fact]
        public void GetByIdTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();

                var expected = repository.GetById(actual.Id);
                Assert.Equal(actual, expected);
            }

        }

        [Fact]
        public void GetByInvalidIdTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var expected = repository.GetById(invalidId);
                Assert.Null(expected);
            }
        }

        [Fact]
        public async Task GetByIdAsyncTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();

                var expected = await repository.GetByIdAsync(actual.Id);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async Task GetByInvalidIdAsyncTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var expected = await repository.GetByIdAsync(invalidId);
                Assert.Null(expected);
            }
        }

        [Fact]
        public void GetTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();

                var expected = repository.Get(w => w.Id == actual.Id);
                Assert.True(expected.Any(w => w.Id == actual.Id));
            }
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();

                var expected = await repository.GetAsync(w => w.Id == actual.Id);
                Assert.True(expected.Any(w => w.Id == actual.Id));
            }
        }

        [Fact]
        public void AddTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();
                var expected = repository.GetById(actual.Id);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void AddRangeTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var list = CreateTestList();

                repository.AddRange(list);
                uow.SaveChanges();
                var ids = list.Select(s => s.Id);
                var gamesExpected = repository.Get(w => ids.Contains(w.Id));
                Assert.Equal(list.Count, gamesExpected.Count);
            }
        }

        [Fact]
        public void UpdateTest()
        {
            var actual = CreateTestObject();
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                repository.Add(actual);
                uow.SaveChanges();
            }

            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                EditTestObeject(actual);
                repository.Update(actual);
                uow.SaveChanges();
                var expected = repository.GetById(actual.Id);
                Assert.Equal(expected.ToString(), actual.ToString());
            }
        }

        [Fact]
        public void UpdateFailChangeNameTest()
        {
            Action testAction = () =>
            {
                using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
                {
                    var actual = CreateTestObject();
                    repository.Update(actual);
                    uow.SaveChanges();
                }
            };

            Assert.Throws(typeof(InvalidOperationException), testAction);
        }

        [Fact]
        public void UpdateRangeTest()
        {
            var list = CreateTestList();
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                repository.AddRange(list);
                uow.SaveChanges();

                foreach (var item in list)
                {
                    EditTestObeject(item);
                }
            }

            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                repository.UpdateRange(list);
                uow.SaveChanges();

                var ids = list.Select(s => s.Id);
                var expecteds = repository.Get(w => ids.Contains(w.Id));
                foreach (var item in expecteds)
                {
                    var expected = list.FirstOrDefault(w => w.Id == item.Id);
                    Assert.Equal(expected.ToString(), item.ToString());
                }
            }
        }

        [Fact]
        void RemoveTest()
        {
            var actual = CreateTestObject();
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                repository.Add(actual);
                uow.SaveChanges();
            }

            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                repository.Remove(actual.Id);
                uow.SaveChanges();

                var expected = repository.GetById(actual.Id);
                Assert.Null(expected);
            }
        }

        [Fact]
        void RemoveRangeTest()
        {
            var list = CreateTestList();
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                repository.AddRange(list);
                uow.SaveChanges();
            }
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var ids = list.Select(s => s.Id).ToList();
                var actual = repository.Get(w => ids.Contains(w.Id));
                repository.RemoveRange(actual);
                uow.SaveChanges();
                var expected = repository.Get(w => ids.Contains(w.Id));
                Assert.False(expected.Any());
            }
        }

        [Fact]
        public void RemoveWithInvalidIdTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                repository.Remove(invalidId);
                uow.SaveChanges();
                Assert.Equal(1, 1);
            }
        }

        [Fact]
        public async void SaveChangeTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();
                var expected = await repository.GetByIdAsync(actual.Id);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void SaveChangeAsyncTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                await uow.SaveChangesAsync();
                var expected = await repository.GetByIdAsync(actual.Id);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void AnyTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();

                Assert.True(repository.Any(w => w.Id == actual.Id));
            }
        }

        [Fact]
        public async Task AnyAsyncTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                uow.SaveChanges();

                Assert.True(await repository.AnyAsync(w => w.Id == actual.Id));
            }
        }

        [Fact]
        public void NotUsingUnitOfWorkFactoryShouldThrowsContextNotCreatedOrNullExceptionTest()
        {
            Action testAction = () =>
            {
                repository.GetById(-1);
            };
            Assert.Throws(typeof(ContextNotCreatedOrNullException), testAction);
        }

        [Fact]
        public void NestedContextTest()
        {
            using (var uow = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
            {
                var actual = CreateTestObject();
                repository.Add(actual);
                using (var uow2 = new UnitOfWorkFactory().Create(ApplicationContextEnum.InMemory))
                {
                    uow2.SaveChanges();
                }
                uow.SaveChanges();

                var expected = repository.GetById(actual.Id);
                Assert.Equal(actual, expected);
            }
        }
    }
}

