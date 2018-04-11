using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using Sashay.Core.Oas.Documents._2._0;
using Sashay.Core.Oas.Schema._2._0;

namespace Sashay.Core.OasGen
{
    public static class Swagger2Generator
    {
        public static Swagger2 GenerateDocument(string title = null, string version = "1.0.0", string description = "Sample Description", 
            string host = "localhost", string basePath = "/")
        {
            string name = title ?? Assembly.GetCallingAssembly().GetName().Name;

            return new Swagger2()
            {
                Info = new Info(description: description, version: version, title: name),
                Host = host,
                BasePath = basePath
            };
        }

        public static Swagger2 GenerateFromRequestMessage(HttpRequestMessage message)
        {
            var title = Assembly.GetCallingAssembly().GetName().Name;
            
            var swagger =  GenerateDocument(host: message.RequestUri.Authority, title:title);
            
            swagger.AddScheme(message.RequestUri.Scheme);

            return swagger;
        }
    }
}
