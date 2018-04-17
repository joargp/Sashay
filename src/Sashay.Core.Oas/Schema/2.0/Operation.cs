using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class Operation
    {
        private List<string> outputFormats;
        
        public Operation(string httpMethod)
        {
            if (string.IsNullOrWhiteSpace(httpMethod))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(httpMethod));
            HttpMethod = httpMethod;
            
            outputFormats = new List<string>();
            
        }
        
        [JsonIgnore]
        public string HttpMethod { get; }
        
        public string OperationId { get; set; }

        public IEnumerable<string> Produces => outputFormats;

        public void AddOutputFormat(string outputFormat)
        {
            if (!outputFormats.Contains(outputFormat))
            {
                outputFormats.Add(outputFormat);
            }
        }
    }
}
