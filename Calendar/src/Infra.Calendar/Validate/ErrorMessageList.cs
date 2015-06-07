using System.Collections.Generic;

namespace Infra.Calendar.Validate
{
    public class ErrorMessageList : Dictionary<string,List<ErrorMessage>>
    {
        public void AddError(string key, ErrorMessage value)
        {
            if (!ContainsKey(key))
                Add(key, new List<ErrorMessage>());
            this[key].Add(value);
            
        }
    }
}
