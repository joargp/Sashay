using System.Net;
using Sashay.Core.OasGen.AzureFunctions.Attributes;
using Sashay.Core.OasGen.AzureFunctions.Parsers;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.ResponseParserTests
{
    public class Parse
    {
        [Fact]
        public void ReturnsResponseObjectWithHttpStatusCode()
        {
            var parser = new ResponseParser();

            var response = parser.Parse(new ProducesResponseAttribute(HttpStatusCode.Accepted));
            
            Assert.Equal(202, response.HttpStatusCode);

        }

        [Fact]
        public void WithoutDescriptionInAttribute_ReturnsResponseWithStatusCodeString()
        {
            var parser = new ResponseParser();

            var response = parser.Parse(new ProducesResponseAttribute(HttpStatusCode.Accepted));
            
            Assert.Equal("Accepted", response.Description);
        }

        [Fact]
        public void WithDescriptionInAttribute_ReturnsResponseWithDescription()
        {
            const string description = "Your request has been accepted.";
            var parser = new ResponseParser();

            var response = parser.Parse(new ProducesResponseAttribute(HttpStatusCode.Accepted, description));
            
            Assert.Equal(description, response.Description);
        }
    }
}
