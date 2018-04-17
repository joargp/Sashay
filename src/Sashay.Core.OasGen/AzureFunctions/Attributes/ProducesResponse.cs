using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Sashay.Core.OasGen.AzureFunctions.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=true)]
    public class ProducesResponseAttribute : ProducesResponseTypeAttribute
    {
        public ProducesResponseAttribute(HttpStatusCode statusCode, string description = null)
            : base((int)statusCode)
        {
            Description = description ?? statusCode.ToString();
        }
        
        public string Description { get; set; }
    }
}
