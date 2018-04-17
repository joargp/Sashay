using System;
using Microsoft.Azure.WebJobs;
using Sashay.Core.Oas.Extensions;

namespace Sashay.Core.OasGen.AzureFunctions.Extensions
{
    public static class HttpTriggerAttributeExtensions
    {
        public static string GetRouteOrDefault(this HttpTriggerAttribute trigger, string defaultRoute = "/")
        {
            if (string.IsNullOrWhiteSpace(defaultRoute))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(defaultRoute));
            return trigger.Route?.AsPath() ?? defaultRoute.AsPath();
        }
    }
}
