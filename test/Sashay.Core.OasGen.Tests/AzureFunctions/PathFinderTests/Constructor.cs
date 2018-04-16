using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.PathFinderTests
{
    public class Constructor
    {
        [Fact]
        public void WithNullGenerationFunctionName_UsesSwaggerAsGenerationName()
        {
            var pathFinder = new PathFinder();
            
            Assert.Equal("Swagger", pathFinder.GenerationFunctionName);
        }

        [Fact]
        public void WithSpecifiedGenerationFunction_StoresGenerationFunctionName()
        {
            const string Generator = "OasGenerator";
            
            var pathFinder = new PathFinder(Generator);
            
            Assert.Equal(Generator, pathFinder.GenerationFunctionName);
        }
    }
}
