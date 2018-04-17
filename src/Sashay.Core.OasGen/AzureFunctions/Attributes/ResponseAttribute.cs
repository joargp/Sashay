using System;
using System.Net;

namespace Sashay.Core.OasGen.AzureFunctions.Attributes
{
    public class ResponseAttribute : Attribute
    {
        public ResponseAttribute(HttpStatusCode statusCode, string description = "")
        {
            StatusCode = statusCode;
            Description = description;
        }
        
        public HttpStatusCode StatusCode { get; set; }
        public string Description { get; set; }
    }
}
