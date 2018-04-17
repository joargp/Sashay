using Sashay.Core.Oas.Documents._2._0;
using Sashay.Core.Oas.Schema._2._0;
using Xunit;

namespace Sashay.Core.Oas.Tests.Documents._2._0
{
    public class SwaggerTests
    {
        [Theory]
        [InlineData("htTp", "http")]
        [InlineData("Https", "https")]
        [InlineData("BaNaNA", "banana")]
        [InlineData("1scheme", "1scheme")]
        [InlineData("SCHEME1", "scheme1")]
        public void AddScheme_ConvertsSchemeToLowerCase(string scheme, string expected)
        {        
            var swagger = new Swagger2();
            
            swagger.AddScheme(scheme);

            Assert.Single(swagger.Schemes);
            Assert.Contains(expected, swagger.Schemes);
        }

        [Theory]
        [InlineData("pet/", "/pet")]
        [InlineData("user/", "/user")]
        [InlineData("/store/order/", "/store/order")]
        public void AddPath_WithNewDocument_AddsPathWithRouteAsKey(string route, string expectedKey)
        {
            var swagger = new Swagger2();
            
            swagger.AddPath(new Path(route));
            
            Assert.Contains(expectedKey, swagger.Paths.Keys);
        }
    }
}
