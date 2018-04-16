using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Xunit;
using MethodInfoExtensions = Sashay.Core.OasGen.AzureFunctions.Extensions.MethodInfoExtensions;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.MethodInfoExtensionsTests
{
    public class GetHttpTrigger
    {
        [Fact]
        public void GetHttpTrigger_WithNullMethodInfo_ThrowsArgumentNullException()
        {
            MethodInfo nullMethod = null;
            
            Assert.Throws<ArgumentNullException>("methodInfo", () => MethodInfoExtensions.GetHttpTrigger(nullMethod));
        }
        
        [Fact]
        public void GetHttpTrigger_WithParameterlessMethod_ReturnsNull()
        {
            var methodInfo = GetType().GetMethod(nameof(ParameterlessMethod));

            var trigger = methodInfo.GetHttpTrigger();
            
            Assert.Null(trigger);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void ParameterlessMethod()
        {
            
        }

        [Fact]
        public void GetHttpTrigger_WithParameteredMothod_WithoutTrigger_ReturnsNull()
        {
            var methodInfo = GetType().GetMethod(nameof(TriggerlessMethod));
            
            var trigger = methodInfo.GetHttpTrigger();
            
            Assert.Null(trigger);
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public void TriggerlessMethod(HttpRequestMessage msg)
        {
            
        }

        [Fact]
        public void GetHttpTrigger_WithHttpTriggeredParameterInMethod_ReturnsHttpTrigger()
        {
            var methodInfo = GetType().GetMethod(nameof(TriggerMethod));

            var trigger = methodInfo.GetHttpTrigger();
            
            Assert.NotNull(trigger);
            Assert.Equal("sample", trigger.Route);
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public static void TriggerMethod([HttpTrigger("get", "post", Route = "sample")]HttpRequest req, TraceWriter log)
        {
            
        }
    }
}
