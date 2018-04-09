using Xunit;

namespace Sashay.Core.OasGen.Tests
{
    public class Swagger2GeneratorTests
    {
        [Fact]
        public void Generate_SetsSwaggerDefaults()
        {
            var swagger = Swagger2Generator.GenerateDocument();
            
            Assert.Equal(swagger.Swagger, "2.0");
            Assert.Equal(swagger.Info.Description, "Sample Description");
            Assert.Equal(swagger.Info.Version, "1.0.0");
            Assert.Equal(swagger.Host, "localhost");
            Assert.Equal(swagger.BasePath, "/");
        }

        [Fact]
        public void Generate_SetsTitleToCallingAssemblyName()
        {
            var swagger = Swagger2Generator.GenerateDocument();
            
            Assert.Equal(swagger.Info.Title, "Sashay.Core.OasGen.Tests");
            
        }

        [Fact]
        public void Generate_WithDescription_SetsSwaggerDescription()
        {
            const string description = "Some random description";
            
            var swagger = Swagger2Generator.GenerateDocument(description: description);
            
            Assert.Equal(swagger.Info.Description, description);
        }

        [Fact]
        public void Generate_WithHost_SetsSwaggerHost()
        {
            const string host = "gitsnub.com";
            
            var swagger = Swagger2Generator.GenerateDocument(host: host);
            
            Assert.Equal(swagger.Host, host);
        }

        [Fact]
        public void Generate_WithBasePath_SetsSwaggerBasePath()
        {
            const string basePath = "api/";

            var swagger = Swagger2Generator.GenerateDocument(basePath: basePath);

            Assert.Equal(swagger.BasePath, basePath);
        }

    }
}
