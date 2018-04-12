using Sashay.Core.Oas.Extensions;
using Xunit;

namespace Sashay.Core.Oas.Tests.Extensions
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("/api", "/api")]
        [InlineData("api", "/api")]
        [InlineData("api/", "/api")]
        [InlineData("/api/", "/api")]
        public void ToPath_AddsLeadingWhack_AndRemovesTrailingWhack(string pathIn, string expectedPath)
        {
            var path = pathIn.AsPath();
            
            Assert.Equal(expectedPath, path);
        }
    }
}
