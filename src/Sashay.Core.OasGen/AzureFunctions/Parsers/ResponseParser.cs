using Sashay.Core.Oas.Schema._2._0;
using Sashay.Core.OasGen.AzureFunctions.Attributes;

namespace Sashay.Core.OasGen.AzureFunctions.Parsers
{
    public class ResponseParser : IResponseParser
    {
        public Response Parse(ProducesResponseAttribute attribute)
        {
            return new Response
            {
                HttpStatusCode = attribute.StatusCode,
                Description = attribute.Description
            };
        }
    }
}
