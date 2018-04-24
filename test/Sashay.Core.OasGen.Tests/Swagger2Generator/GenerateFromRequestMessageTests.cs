using System.Linq;
using System.Net.Http;
using Xunit;

namespace Sashay.Core.OasGen.Tests.Swagger2Generator
{
    public class GenerateFromRequestMessageTests
    {
        
        [Fact]
        public void SetsTitleToCallingAssemblyName()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "http://google.com.au");

            var swagger = OasGen.Swagger2Generator.GenerateFromRequestMessage(message);
            
            Assert.Equal(swagger.Info.Title, "Sashay.Core.OasGen.Tests");
        }
        
        [Fact]
        public void WithRequestMessage_UsesRequestHost()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "http://google.com.au");

            var swagger = OasGen.Swagger2Generator.GenerateFromRequestMessage(message);
            
            Assert.Equal("google.com.au", swagger.Host);
        }

        [Fact]
        public void WithRequestMessage_IncludesHostPort()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "http://google.com.au:3098");

            var swagger = OasGen.Swagger2Generator.GenerateFromRequestMessage(message);
            
            Assert.Equal("google.com.au:3098", swagger.Host);
        }

        [Theory]
        [InlineData("https://google.com.au:3098", "https")]
        [InlineData("http://google.com.au:3098", "http")]
        public void WithRequestMessage(string requestUri, string expectedScheme)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var swagger = OasGen.Swagger2Generator.GenerateFromRequestMessage(message);
            
            Assert.Single(swagger.Schemes);
            Assert.Contains(expectedScheme, swagger.Schemes);
        }
    }
}
