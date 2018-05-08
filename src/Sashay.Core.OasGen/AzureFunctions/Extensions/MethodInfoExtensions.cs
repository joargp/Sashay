using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Sashay.Core.OasGen.AzureFunctions.Extensions
{
    public static class MethodInfoExtensions
    {
        public static HttpTriggerAttribute GetHttpTrigger(this MethodInfo methodInfo)
        {
            if (methodInfo == null) throw new ArgumentNullException(nameof(methodInfo));

            return methodInfo.GetParameters()
                .Where(p => p.GetCustomAttribute<HttpTriggerAttribute>() != null)
                .Select(p => p.GetCustomAttribute<HttpTriggerAttribute>())
                .SingleOrDefault();
        }

        public static string GetFunctionName(this MethodInfo methodInfo)
        {
            if (methodInfo == null) throw new ArgumentNullException(nameof(methodInfo));

            return methodInfo.GetCustomAttribute<FunctionNameAttribute>()?.Name;
        }

        public static bool IsAzureFunction(this MethodInfo methodInfo)
        {
            if (methodInfo == null) throw new ArgumentNullException(nameof(methodInfo));
            
            return methodInfo.GetCustomAttributes<FunctionNameAttribute>(false).Any();
        }
        
        public static IEnumerable<ParameterInfo> GetFunctionParameters(this MethodInfo methodInfo)
        {
            if (methodInfo == null) throw new ArgumentNullException(nameof(methodInfo));

            var excludedTypes = new[] {typeof(ILogger), typeof(TraceWriter), typeof(HttpRequestMessage)};

            return methodInfo.GetParameters().Where(p => !excludedTypes.Contains(p.ParameterType));
        }
         
    }
}
