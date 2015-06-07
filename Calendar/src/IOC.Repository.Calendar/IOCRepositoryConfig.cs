using EF.Repository.Calendar;
using Microsoft.Framework.DependencyInjection;
using Repository.Calendar;
using System.Collections.Generic;

namespace IOC.Repository.Calendar
{
    public class IOCRepositoryConfig
    {
        public static IEnumerable<ServiceDescriptor> config()
        {
            var configs = new List<ServiceDescriptor>();

            configs.Add(ServiceDescriptor.Singleton<IGameRepository, GameRepository>());
            configs.Add(ServiceDescriptor.Scoped<IUnitOfWorkFactory, UnitOfWorkFactory>());

            return configs;
        }
    }
}
