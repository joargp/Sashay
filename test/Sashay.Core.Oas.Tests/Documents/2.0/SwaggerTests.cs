using System.Linq;
using Sashay.Core.Oas.Documents._2._0;
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
        [InlineData("1SCHEME", "1scheme")]
        public void AddScheme_ConvertsSchemeToLowerCase(string scheme, string expected)
        {        
            var swagger = new Swagger2();
            
            swagger.AddScheme(scheme);

            Assert.Equal(1, swagger.Schemes.Count());
            Assert.Contains(expected, swagger.Schemes);
        }
    }
}
