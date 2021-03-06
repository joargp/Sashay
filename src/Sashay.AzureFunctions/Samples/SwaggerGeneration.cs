﻿using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Sashay.Core.OasGen;

namespace Sashay.AzureFunctions.Samples
{
    public static class SwaggerGeneration
    {
        [FunctionName("Swagger2")]
        public static IActionResult Run([HttpTrigger("get", Route = "swagger")] HttpRequestMessage msg, ILogger log, ExecutionContext context)
        {
            return new OkObjectResult(Swagger2Generator.GenerateFromRequestMessage(msg, context, log));
        }
    }
}
