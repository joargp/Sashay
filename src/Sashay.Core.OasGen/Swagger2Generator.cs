using System.Net.Http;
using System.Reflection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Sashay.Core.Oas.Documents._2._0;
using Sashay.Core.Oas.Schema._2._0;
using Sashay.Core.OasGen.AzureFunctions;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Sashay.Core.OasGen.AzureFunctions.Parsers;

namespace Sashay.Core.OasGen
{
    public static class Swagger2Generator
    {
        public static Swagger2 GenerateDocument(string title = null, string version = "1.0.0", string description = "Sample Description", 
            string host = "localhost", string basePath = "/api", ExecutionContext context = null)
        {
            var name = title ?? Assembly.GetCallingAssembly().GetName().Name;

            if (context != null)
            {
                //TODO: Throw some testing in around path formats for / \ locations
                var hostConfig = context.GetHostConfiguration();
                basePath = string.IsNullOrEmpty(hostConfig.Http.RoutePrefix)
                    ? basePath
                    : $"/{hostConfig.Http.RoutePrefix}";

                return new Swagger2
                {
                    Info = new Info(description, version, name),
                    Host = host,
                    BasePath = basePath
                };
            }
            
            return new Swagger2
            {
                Info = new Info(description, version, name),
                Host = host,
                BasePath = basePath
            };
        }

        public static Swagger2 GenerateFromRequestMessage(HttpRequestMessage message, 
            ExecutionContext context = null, ILogger logger = null)
        {
            var assembly = Assembly.GetCallingAssembly();
            
            var title = assembly.GetName().Name;
            
            var swagger = GenerateDocument(host: message.RequestUri.Authority, title:title, context: context);
            
            swagger.AddScheme(message.RequestUri.Scheme);

            var paths = new PathFinder(new OperationParser(), new ResponseParser(), new ParameterParser(),
                context?.FunctionName).FindPaths(assembly);
            foreach (var path in paths)
            {
                swagger.AddPath(path);
            }

            return swagger;
        }
    }
}
