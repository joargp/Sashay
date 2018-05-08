using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.MethodInfoExtensionsTests
{
    public class GetFunctionParameters
    {
        [Fact]
        public void WithNullMethodInfo_ThrowsArgumentNullException()
        {
            MethodInfo nullMethod = null;
            
            Assert.Throws<ArgumentNullException>("methodInfo", () => nullMethod.GetFunctionParameters());
        }

        [Theory]
        [InlineData(typeof(HttpRequestMessage))]
        [InlineData(typeof(TraceWriter))]
        [InlineData(typeof(ILogger))]
        public void ExcludesFunctionRuntimeSuppliedParameterTypes(Type excludedType)
        {
            var methodInfo = GetType().GetMethod(nameof(AzureRuntimeParametersMethod));

            var parameters = methodInfo.GetFunctionParameters();

            Assert.Single(parameters);
            Assert.DoesNotContain(parameters, p => p.ParameterType == excludedType);
        }

        public void AzureRuntimeParametersMethod(HttpRequestMessage message, string someData, ILogger logger,
            TraceWriter trace)
        {
            
        }
    }
}