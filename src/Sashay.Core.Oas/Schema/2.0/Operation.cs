using System;
using Newtonsoft.Json;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class Operation
    {
        public Operation(string httpMethod)
        {
            if (string.IsNullOrWhiteSpace(httpMethod))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(httpMethod));
            HttpMethod = httpMethod;
        }
        
        [JsonIgnore]
        public string HttpMethod { get; }
    }
}
