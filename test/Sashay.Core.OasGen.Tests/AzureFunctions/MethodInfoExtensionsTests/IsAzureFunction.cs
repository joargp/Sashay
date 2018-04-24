using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Azure.WebJobs;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.MethodInfoExtensionsTests
{
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "xUnit1013")]
    public class IsAzureFunction
    {
        [Fact]
        public void WithNullMethodInfo_ThrowsArgumentNullException()
        {
            MethodInfo nullMethod = null;
            
            Assert.Throws<ArgumentNullException>("methodInfo", () => nullMethod.IsAzureFunction());
        }

        [Fact]
        public void WithNoAzureFunctionNameAttribute_ReturnsFalse()
        {
            var methodInfo = GetType().GetMethod(nameof(NoFunctionAttribute));
            
            Assert.False(methodInfo.IsAzureFunction());
        }
        
        public void NoFunctionAttribute()
        {
            
        }

        [Fact]
        public void WithAzureFunctionAttribute_ReturnsTrue()
        {
            var methodInfo = GetType().GetMethod(nameof(MyAzureFunction));
            
            Assert.True(methodInfo.IsAzureFunction());
        }
        
        [FunctionName("xxx")]
        public void MyAzureFunction()
        {
            
        }
    }
}
