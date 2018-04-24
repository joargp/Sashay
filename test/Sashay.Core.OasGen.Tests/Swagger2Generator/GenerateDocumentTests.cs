using Xunit;

namespace Sashay.Core.OasGen.Tests.Swagger2Generator
{
    public class GenerateDocumentTests
    {
        [Fact]
        public void SetsSwaggerDefaults()
        {
            var swagger = OasGen.Swagger2Generator.GenerateDocument();
            
            Assert.Equal("2.0", swagger.Swagger);
            Assert.Equal("Sample Description", swagger.Info.Description);
            Assert.Equal("1.0.0", swagger.Info.Version);
            Assert.Equal("localhost", swagger.Host);
            Assert.Equal("/api", swagger.BasePath);
        }

        [Fact]
        public void SetsTitleToCallingAssemblyName()
        {
            var swagger = OasGen.Swagger2Generator.GenerateDocument();
            
            Assert.Equal("Sashay.Core.OasGen.Tests", swagger.Info.Title);
        }

        [Fact]
        public void WithDescription_SetsSwaggerDescription()
        {
            const string description = "Some random description";
            
            var swagger = OasGen.Swagger2Generator.GenerateDocument(description: description);
            
            Assert.Equal(description, swagger.Info.Description);
        }

        [Fact]
        public void WithHost_SetsSwaggerHost()
        {
            const string host = "gitsnub.com";
            
            var swagger = OasGen.Swagger2Generator.GenerateDocument(host: host);
            
            Assert.Equal(host, swagger.Host);
        }

        [Fact]
        public void WithBasePath_SetsSwaggerBasePath()
        {
            const string basePath = "api/";

            var swagger = OasGen.Swagger2Generator.GenerateDocument(basePath: basePath);

            Assert.Equal(basePath, swagger.BasePath);
        }

    }
}
