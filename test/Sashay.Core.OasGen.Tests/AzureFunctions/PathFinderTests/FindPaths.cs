using System.Linq;
using System.Reflection;
using NSubstitute;
using Sashay.Core.FakeFunctions;
using Sashay.Core.FakeFunctions.NamespaceIncluded;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.PathFinderTests
{
    public class FindPaths
    {
        [Theory]
        [InlineData(null)]
        [InlineData("Swagger")]
        [InlineData("OasGenerator")]
        public void ExcludesGenerationFunctionPath(string generationFunctionName)
        {
            var operationParser = Substitute.For<IOperationParser>();
            var assembly = Assembly.GetAssembly(typeof(TestFunctions));
            var pathFinder = new PathFinder(operationParser, generationFunctionName);

            var paths = pathFinder.FindPaths(assembly).ToList();
            
            Assert.NotEmpty(paths);
            Assert.DoesNotContain(paths, p => p.Route.Equals(pathFinder.GenerationFunctionName));
        }

        [Fact]
        public void WithSpecifiedNamespace_IncludesOnlyFunctionsFromNamespace()
        {
            var operationParser = Substitute.For<IOperationParser>();
            var assembly = Assembly.GetAssembly(typeof(TestFunctions));
            var pathFinder = new PathFinder(operationParser);

            var paths = pathFinder.FindPaths(assembly, typeof(IncNamespaceFuncs).Namespace).ToList();
            
            Assert.NotEmpty(paths);
            Assert.Contains(paths, p => p.Route.Equals("/included1"));
            Assert.Contains(paths, p => p.Route.Equals("/included2"));
            Assert.DoesNotContain(paths, p => !p.Route.StartsWith("/included"));
        }
    }
}
