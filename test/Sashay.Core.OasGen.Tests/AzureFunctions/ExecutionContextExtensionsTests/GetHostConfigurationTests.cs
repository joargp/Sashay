using System.IO;
using Microsoft.Azure.WebJobs;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.ExecutionContextExtensionsTests
{
    public class GetHostConfigurationTests
    {
        [Fact]
        public void WithNullContext_ReturnsEmptyConfiguration()
        {
            var hostConfig = ExecutionContextExtensions.GetHostConfiguration(null);

            Assert.NotNull(hostConfig);
            Assert.NotNull(hostConfig.Http);
            Assert.NotNull(hostConfig.Http.RoutePrefix);
            Assert.Equal(string.Empty, hostConfig.Http.RoutePrefix);
        }

        [Fact]
        public void WithNullAppDirectoryInContext_ReturnsEmptyConfiguration()
        {
            var context = new ExecutionContext
            {
                FunctionAppDirectory = null
            };

            var hostConfig = context.GetHostConfiguration();

            Assert.NotNull(hostConfig);
            Assert.NotNull(hostConfig.Http);
            Assert.NotNull(hostConfig.Http.RoutePrefix);
            Assert.Equal(string.Empty, hostConfig.Http.RoutePrefix);
        }

        [Fact]
        public void WithHostFileMissing_ReturnsEmptyConfiguration()
        {
            var context = new ExecutionContext
            {
                FunctionAppDirectory = Directory.GetCurrentDirectory()
            };
            var hostConfig = context.GetHostConfiguration();

            Assert.NotNull(hostConfig);
            Assert.NotNull(hostConfig.Http);
            Assert.NotNull(hostConfig.Http.RoutePrefix);
            Assert.Equal(string.Empty, hostConfig.Http.RoutePrefix);
        }

        [Theory]
        [InlineData("NoRoute1", "{}")]
        [InlineData("NoRoute2", "{ \"http\": {\"maxOutstandingRequests\": 20}}")]
        [InlineData("NoRoute3", "{ \"http\": {\"maxOutstandingRequests\": 20, \"dynamicThrottlesEnabled\": false}}")]
        public void WithoutRouteInHostFile_ReturnsEmptyRouteInConfiguration(string directoryName,
            string hostFileContent)
        {
            var hostFileDirectory = Path.Combine(Directory.GetCurrentDirectory(), directoryName);
            var fileName = WriteHostFile(hostFileDirectory, hostFileContent);
            var context = new ExecutionContext
            {
                FunctionAppDirectory = hostFileDirectory
            };

            var hostConfig = context.GetHostConfiguration();

            Assert.NotNull(hostConfig);
            Assert.NotNull(hostConfig.Http);
            Assert.NotNull(hostConfig.Http.RoutePrefix);
            Assert.Equal(string.Empty, hostConfig.Http.RoutePrefix);

            DeleteHostFile(fileName, hostFileDirectory);
        }

        [Fact]
        public void WithRouteInHostFile_ReturnsRouteInConfiguration()
        {
            var hostFileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ValidHostFile");

            var fileName = WriteHostFile(hostFileDirectory, "{\"http\": {\"routePrefix\": \"sandwich\"}}");
            var context = new ExecutionContext
            {
                FunctionAppDirectory = hostFileDirectory
            };

            var hostConfig = context.GetHostConfiguration();

            Assert.NotNull(hostConfig);
            Assert.NotNull(hostConfig.Http);
            Assert.NotNull(hostConfig.Http.RoutePrefix);
            Assert.Equal("sandwich", hostConfig.Http.RoutePrefix);

            DeleteHostFile(fileName, hostFileDirectory);
        }

        private string WriteHostFile(string directory, string contents)
        {
            Directory.CreateDirectory(directory);
            var fileName = Path.Combine(directory, ExecutionContextExtensions.HostFileName);
            File.WriteAllText(fileName, contents);
            return fileName;
        }

        private void DeleteHostFile(string fileName, string directory)
        {
            File.Delete(fileName);
            Directory.Delete(directory);
        }
    }
}
