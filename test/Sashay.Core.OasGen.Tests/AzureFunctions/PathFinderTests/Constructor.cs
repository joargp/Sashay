using NSubstitute;
using Sashay.Core.OasGen.AzureFunctions.Parsers;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.PathFinderTests
{
    public class Constructor
    {
        [Fact]
        public void WithNullGenerationFunctionName_UsesSwaggerAsGenerationName()
        {
            var operationParser = Substitute.For<IOperationParser>();
            var responseParser = Substitute.For<IResponseParser>();
            var pathFinder = new PathFinder(operationParser, responseParser);
            
            Assert.Equal("Swagger", pathFinder.GenerationFunctionName);
        }

        [Fact]
        public void WithSpecifiedGenerationFunction_StoresGenerationFunctionName()
        {
            var operationParser = Substitute.For<IOperationParser>();
            var responseParser = Substitute.For<IResponseParser>();
            const string generator = "OasGenerator";
            
            var pathFinder = new PathFinder(operationParser, responseParser, generator);
            
            Assert.Equal(generator, pathFinder.GenerationFunctionName);
        }
    }
}
