using Infra.Calendar.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Service.Fakes
{
    public class DateTimeHelperFake : IDateTimeHelper
    {
        public DateTimeOffset Now()
        {
            return new DateTime(2015, 10, 20);
        }

        public DateTime Today()
        {
            throw new NotImplementedException();
        }
    }
}
