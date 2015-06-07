using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Calendar.Helper
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTimeOffset Now()
        {
            return DateTimeOffset.Now;
        }

        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}
