using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Xunit;


namespace Sashay.Core.OasGen.Tests.AzureFunctions.MethodInfoExtensionsTests
{
    [SuppressMessage("ReSharper", "xUnit1013")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedParameter.Global")]
    public class GetHttpTrigger
    {
        [Fact]
        public void WithNullMethodInfo_ThrowsArgumentNullException()
        {
            MethodInfo nullMethod = null;
            
            Assert.Throws<ArgumentNullException>("methodInfo", () => nullMethod.GetHttpTrigger());
        }
        
        [Fact]
        public void WithParameterlessMethod_ReturnsNull()
        {
            var methodInfo = GetType().GetMethod(nameof(ParameterlessMethod));

            var trigger = methodInfo.GetHttpTrigger();
            
            Assert.Null(trigger);
        }

        public static void ParameterlessMethod()
        {
            
        }

        [Fact]
        public void WithParameteredMothod_WithoutTrigger_ReturnsNull()
        {
            var methodInfo = GetType().GetMethod(nameof(TriggerlessMethod));
            
            var trigger = methodInfo.GetHttpTrigger();
            
            Assert.Null(trigger);
        }
        
        public static void TriggerlessMethod(HttpRequestMessage msg)
        {
            
        }

        [Fact]
        public void WithHttpTriggeredParameterInMethod_ReturnsHttpTrigger()
        {
            var methodInfo = GetType().GetMethod(nameof(TriggerMethod));

            var trigger = methodInfo.GetHttpTrigger();
            
            Assert.NotNull(trigger);
            Assert.Equal("sample", trigger.Route);
        }
        
        
        public static void TriggerMethod([HttpTrigger("get", "post", Route = "sample")]HttpRequest req, ILogger log)
        {
            
        }
    }
}
