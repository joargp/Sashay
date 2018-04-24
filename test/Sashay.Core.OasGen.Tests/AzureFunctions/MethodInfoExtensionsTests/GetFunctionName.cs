using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Azure.WebJobs;
using Xunit;
using Sashay.Core.OasGen.AzureFunctions.Extensions;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.MethodInfoExtensionsTests
{
    [SuppressMessage("ReSharper", "xUnit1013")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
    public class GetFunctionName
    {
        [Fact]
        public void WithNullMethodInfo_ThrowsArgumentNullException()
        {
            MethodInfo nullMethod = null;
            
            Assert.Throws<ArgumentNullException>("methodInfo", () => nullMethod.GetFunctionName());
        }

        [Fact]
        public void WithNoAzureFunctionNameAttribute_ReturnsNull()
        {
            var methodInfo = GetType().GetMethod(nameof(NonFunctionMethod));
            
            Assert.Null(methodInfo.GetFunctionName());
        }

        public void NonFunctionMethod()
        {
            
        }

        [Fact]
        public void WithAzureFunctionAttribute_ReturnsFunctionName()
        {
            var methodInfo = GetType().GetMethod(nameof(AzureFunction));
            
            Assert.Equal("MyAzureFunction", methodInfo.GetFunctionName());
        }

        [FunctionName("MyAzureFunction")]
        public void AzureFunction()
        {
            
        }
    }
}
