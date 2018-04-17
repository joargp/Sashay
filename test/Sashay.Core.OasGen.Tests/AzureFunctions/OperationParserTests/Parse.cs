using Sashay.Core.OasGen.AzureFunctions;
using Sashay.Core.OasGen.AzureFunctions.Parsers;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.OperationParserTests
{
    public class Parse
    {

        [Fact]
        public void SetsHttpMethod()
        {
            const string functionName = "Users";
            const string httpMethod = "get";
            var parser = new OperationParser();
            
            var operation = parser.Parse(httpMethod, functionName);
            
            Assert.Equal(httpMethod, operation.HttpMethod);
        }
        
        [Fact]
        public void SetsOperationIdToConcatentationOfHttpVerbAndFunctionName()
        {
            const string functionName = "Users";
            const string httpMethod = "post";
            var parser = new OperationParser();

            var operation = parser.Parse(httpMethod, functionName);
            
            Assert.Equal("postUsers", operation.OperationId);
        }

        [Fact]
        public void SetsDefaultOutputToJson()
        {
            const string functionName = "Users";
            const string httpMethod = "post";
            var parser = new OperationParser();

            var operation = parser.Parse(httpMethod, functionName);
            
            Assert.Single(operation.Produces, "application/json");
        }
    }
}
