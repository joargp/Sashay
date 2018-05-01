using System.Linq;
using Sashay.Core.FakeFunctions.ResponseAttributes;
using Sashay.Core.OasGen.AzureFunctions.Parsers;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.ResponseParserTests
{
    public class ParseMethodInfo
    {
        [Fact]
        public void WithMethodWithoutPRoducesResponseAttributes_ReturnsDefaultAttibute()
        {
            var functionMethod = typeof(ResponseAttributeFuncs).GetMethod(nameof(ResponseAttributeFuncs.NoResponseAttribute));
            var parser = new ResponseParser();

            var responses = parser.Parse(functionMethod);

            var onlyResponse = Assert.Single(responses);
            Assert.Equal(parser.DefaultResponse.HttpStatusCode, onlyResponse.HttpStatusCode);
            Assert.Equal(parser.DefaultResponse.Description, onlyResponse.Description);
        }

        [Fact]
        public void WithFunctionWithProducesResponseAttrbiutes_ReturnsParsedAttributes()
        {
            var functionMethod = typeof(ResponseAttributeFuncs).GetMethod(nameof(ResponseAttributeFuncs.DeleteUser));
            var parser = new ResponseParser();

            var responses = parser.Parse(functionMethod);
            
            Assert.Equal(2, responses.Count());
            Assert.Contains(responses, r => r.HttpStatusCode == 204);
            Assert.Contains(responses, r => r.HttpStatusCode == 404);
        }
    }
}
