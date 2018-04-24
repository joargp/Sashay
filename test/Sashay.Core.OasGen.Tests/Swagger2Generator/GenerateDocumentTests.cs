using Xunit;

namespace Sashay.Core.OasGen.Tests.Swagger2Generator
{
    public class GenerateDocumentTests
    {
        [Fact]
        public void SetsSwaggerDefaults()
        {
            var swagger = OasGen.Swagger2Generator.GenerateDocument();
            
            Assert.Equal(swagger.Swagger, "2.0");
            Assert.Equal(swagger.Info.Description, "Sample Description");
            Assert.Equal(swagger.Info.Version, "1.0.0");
            Assert.Equal(swagger.Host, "localhost");
            Assert.Equal(swagger.BasePath, "/api");
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
