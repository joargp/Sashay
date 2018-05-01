using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public Response DefaultResponse => new Response {HttpStatusCode = 200, Description = "Ok"};

        public IEnumerable<Response> Parse(MethodInfo functionMethod)
        {
            var responseAttributes = functionMethod.GetCustomAttributes<ProducesResponseAttribute>().ToArray();
            return responseAttributes.Any()
                ? responseAttributes.Select(Parse)
                : new[] {DefaultResponse};
        }
    }
}
