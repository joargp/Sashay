﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace Sashay.Core.FakeFunctions.NamespaceIncluded
{
    public class IncNamespaceFuncs
    {
        [FunctionName("IncludedFunction")]
        public static IActionResult Run([HttpTrigger("get", "post", Route = "Included1")]HttpRequest req, 
            TraceWriter log)
        {
            
            return null;
        }
        
        [FunctionName("IncludedFunction2")]
        public static IActionResult Run2([HttpTrigger("get", "put", Route = "Included2")]HttpRequest req, 
            TraceWriter log)
        {
            
            return null;
        }
    }
}
