using System.ComponentModel;
using System.Reflection;
using Sashay.Core.Oas.Documents._2._0;
using Sashay.Core.Oas.Schema._2._0;

namespace Sashay.Core.OasGen
{
    public static class Swagger2Generator
    {
        public static Swagger2 GenerateDocument(string version = "1.0.0", string description = "Sample Description", 
            string host = "localhost", string basePath = "/")
        {
            var assembly = Assembly.GetCallingAssembly();

            return new Swagger2()
            {
                Info = new Info(description: description, version: version, title: assembly.GetName().Name),
                Host = host,
                BasePath = basePath

            };
        }
    }
}
