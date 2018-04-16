﻿using System.Linq;
using System.Reflection;
using Sashay.Core.FakeFunctions;
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
            var assembly = Assembly.GetAssembly(typeof(TestFunctions));
            var pathFinder = new PathFinder(generationFunctionName);

            var paths = pathFinder.FindPaths(assembly).ToList();
            
            Assert.NotEmpty(paths);
            Assert.DoesNotContain(paths, p => p.Route.Equals(pathFinder.GenerationFunctionName));
        }
    }
}
