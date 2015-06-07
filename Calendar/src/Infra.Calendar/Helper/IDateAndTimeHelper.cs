using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Calendar.Helper
{
    public interface IDateTimeHelper
    {
        DateTimeOffset Now();
        DateTime Today();
    }
}
