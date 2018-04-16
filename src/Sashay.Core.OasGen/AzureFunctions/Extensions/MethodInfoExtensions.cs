﻿using System;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.WebJobs;

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
    }
}
