using Infra.Calendar.Enum;

namespace Infra.Calendar.Validate
{
    public class ErrorMessage
    {
        public ErrorMessage(string Description, ErrorType errorType = ErrorType.Error)
        {
            this.Description = Description;
            this.ErrorType = errorType;
        }

        public ErrorType ErrorType { get; set; }
        public string Description { get; set; }
    }
}
