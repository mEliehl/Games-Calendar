using System;

namespace Domain.Calendar
{
    public class Game : Identity
    {
        public string Name { get; set; }

        public DateTimeOffset Release { get; set; }
    }
}
