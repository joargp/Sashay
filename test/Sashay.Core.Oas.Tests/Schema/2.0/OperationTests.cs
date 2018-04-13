using System;
using Sashay.Core.Oas.Schema._2._0;
using Xunit;

namespace Sashay.Core.Oas.Tests.Schema._2._0
{
    public class OperationTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void Constructor_WithNullOrEmptyHttpMethod_ThrowsException(string httpMethod)
        {
            Assert.Throws<ArgumentException>("httpMethod", () => new Operation(httpMethod));
        }
    }
}
