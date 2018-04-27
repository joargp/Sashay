using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Sashay.Core.OasGen;

using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sashay.AzureFunctions.Samples
{
    public static class Swagger2
    {
        [FunctionName("Swagger2")]
        public static IActionResult Run([HttpTrigger("get", Route = "swagger")] HttpRequestMessage msg, TraceWriter log, ExecutionContext context)
        {
            return new OkObjectResult(Swagger2Generator.GenerateFromRequestMessage(msg, context, log));
        }
    }
}
