using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Sashay.Core.OasGen.AzureFunctions.Attributes;

namespace Sashay.Core.FakeFunctions.ResponseAttributes
{
    public class ResponseAttributeFuncs
    {
        [FunctionName("GetUser")]
        [ProducesResponse(HttpStatusCode.OK)]
        public static IActionResult GetUser([HttpTrigger("get", Route = "user")]HttpRequest req)
        {
            
            return null;
        }
        
        [FunctionName("CreateUser")]
        [ProducesResponse(HttpStatusCode.Created, Description = "Successfully created a user")]
        public static IActionResult PostUser([HttpTrigger("post", Route = "user")]HttpRequest req)
        {
            
            return null;
        }

        [FunctionName("DeleteUser")]
        [ProducesResponse(HttpStatusCode.NoContent)]
        [ProducesResponse(HttpStatusCode.NotFound)]
        public static IActionResult DeleteUser([HttpTrigger("delete", Route = "user")]HttpRequest req)
        {
            return null;
        }
    }
}
