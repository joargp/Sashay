using Newtonsoft.Json;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class Response
    {
        [JsonIgnore]
        public int HttpStatusCode { get; set; }
        
        public string Description { get; set; }
    }
}
