using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class Operation
    {
        private List<string> outputFormats;
        private List<Response> responses;
        
        public Operation(string httpMethod)
        {
            if (string.IsNullOrWhiteSpace(httpMethod))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(httpMethod));
            HttpMethod = httpMethod;
            
            outputFormats = new List<string>();
            responses = new List<Response>();
            
        }
        
        [JsonIgnore]
        public string HttpMethod { get; }
        
        public string OperationId { get; set; }

        public IEnumerable<string> Produces => outputFormats;
        
        public IReadOnlyDictionary<int, Response> Responses => responses.ToDictionary(r => r.HttpStatusCode, el => el);

        public void AddOutputFormat(string outputFormat)
        {
            if (!outputFormats.Contains(outputFormat))
            {
                outputFormats.Add(outputFormat);
            }
        }

        public void AddResponses(IEnumerable<Response> responses)
        {
            this.responses.AddRange(responses);
        }
    }
}
