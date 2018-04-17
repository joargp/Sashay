using NSubstitute;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.PathFinderTests
{
    public class Constructor
    {
        [Fact]
        public void WithNullGenerationFunctionName_UsesSwaggerAsGenerationName()
        {
            var operationParser = Substitute.For<IOperationParser>();
            var pathFinder = new PathFinder(operationParser);
            
            Assert.Equal("Swagger", pathFinder.GenerationFunctionName);
        }

        [Fact]
        public void WithSpecifiedGenerationFunction_StoresGenerationFunctionName()
        {
            var operationParser = Substitute.For<IOperationParser>();
            const string generator = "OasGenerator";
            
            var pathFinder = new PathFinder(operationParser, generator);
            
            Assert.Equal(generator, pathFinder.GenerationFunctionName);
        }
    }
}
