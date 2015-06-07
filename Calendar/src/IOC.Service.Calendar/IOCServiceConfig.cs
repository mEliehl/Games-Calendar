using Microsoft.Framework.DependencyInjection;
using Service.Calendar;
using Service.Calendar.Impl;
using System.Collections.Generic;

namespace IOC.Service.Calendar
{
    public class IOCServiceConfig
    {
        public static IEnumerable<ServiceDescriptor> config()
        {
            var configs = new List<ServiceDescriptor>();

            configs.Add(ServiceDescriptor.Singleton<IGameService, GameService>());

            return configs;
        }
    }
}
