﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Sashay.Core.FakeFunctions
{
    public class TestFunctions
    {
        [FunctionName("SampleFunction")]
        public static IActionResult Run([HttpTrigger("get", "post", Route = null)]HttpRequest req, 
            ILogger log)
        {
            
            return null;
        }
        
        [FunctionName("AdditionalFunction")]
        public static IActionResult Run2([HttpTrigger("get", "put", Route = "additional")]HttpRequest req, 
            ILogger log)
        {
            
            return null;
        }
        
        [FunctionName("GeneratorFunction")]
        public static IActionResult GeneratorFunction([HttpTrigger("get", "put", Route = "metadata/generate")]HttpRequest req)
        {
            
            return null;
        }
        
        [FunctionName("Swagger")]
       
        public static IActionResult SwaggerFunction([HttpTrigger("get", "put", Route = "metadata/swagger")]HttpRequest req)
        {
            
            return null;
        }
    }
}
