using System.Linq;
using System.Reflection;
using NSubstitute;
using NSubstitute.Core.Arguments;
using Sashay.Core.FakeFunctions;
using Sashay.Core.FakeFunctions.NamespaceIncluded;
using Sashay.Core.Oas.Schema._2._0;
using Sashay.Core.OasGen.AzureFunctions.Parsers;
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
            var operationParser = new OperationParser();
            var responseParser = Substitute.For<IResponseParser>();
            var assembly = Assembly.GetAssembly(typeof(TestFunctions));
            var pathFinder = new PathFinder(operationParser, responseParser, generationFunctionName);

            var paths = pathFinder.FindPaths(assembly).ToList();
            
            Assert.NotEmpty(paths);
            Assert.DoesNotContain(paths, p => p.Route.Equals(pathFinder.GenerationFunctionName));
        }

        [Fact]
        public void WithSpecifiedNamespace_IncludesOnlyFunctionsFromNamespace()
        {
            var operationParser = new OperationParser();
            var responseParser = Substitute.For<IResponseParser>();
            var assembly = Assembly.GetAssembly(typeof(TestFunctions));
            var pathFinder = new PathFinder(operationParser, responseParser);

            var paths = pathFinder.FindPaths(assembly, typeof(IncNamespaceFuncs).Namespace).ToList();
            
            Assert.NotEmpty(paths);
            Assert.Contains(paths, p => p.Route.Equals("/included1"));
            Assert.Contains(paths, p => p.Route.Equals("/included2"));
            Assert.DoesNotContain(paths, p => !p.Route.StartsWith("/included"));
        }
    }
}
