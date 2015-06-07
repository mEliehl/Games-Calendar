using System;

namespace EF.Repository.Calendar
{
    public class ContextNotCreatedOrNullException : Exception
    {
        private static string message = "The Context is not created or null";

        public ContextNotCreatedOrNullException() : base(message)
        {
            
        }
    }
}
