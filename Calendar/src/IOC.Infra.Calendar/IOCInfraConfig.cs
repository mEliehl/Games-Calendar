using Infra.Calendar.Helper;
using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace IOC.Infra.Calendar
{
    public class IOCInfraConfig
    {
        public static IEnumerable<ServiceDescriptor> config()
        {
            var configs = new List<ServiceDescriptor>();

            configs.Add(ServiceDescriptor.Singleton<IDateTimeHelper, DateTimeHelper>());

            return configs;
        }
    }
}
