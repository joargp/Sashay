using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.Azure.WebJobs.Host;
using Sashay.Core.Oas.Schema._2._0;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using System;
using Sashay.Core.OasGen.AzureFunctions.Parsers;

namespace Sashay.Core.OasGen
{
    public class PathFinder
    {
        private readonly IOperationParser operationParser;
        private readonly IResponseParser responseParser;
        private readonly IParameterParser parameterParser;
        public TraceWriter logger { get; set; }


        public PathFinder(IOperationParser operationParser, IResponseParser responseParser, 
            IParameterParser parameterParser,
            string generationFunctionName = null)
        {
            this.operationParser = operationParser;
            this.responseParser = responseParser;
            this.parameterParser = parameterParser;
            GenerationFunctionName = generationFunctionName ?? "Swagger";
        }

        public string GenerationFunctionName { get;  }

        public IEnumerable<Path> FindPaths(Assembly assembly, string inNamespace = "")
        {
            var namespaceFilter = string.IsNullOrEmpty(inNamespace)
                ? (t => true)
                : new Func<Type, bool>(t => t.Namespace.Equals(inNamespace));
                
            
            var functionMethods = assembly.GetTypes()
                .Where(namespaceFilter)
                .SelectMany(t => t.GetMethods())
                .Where(m => m.IsAzureFunction())
                .ToArray();
            
            foreach (var method in functionMethods)
            {
                var functionName = method.GetFunctionName();

                if (functionName == GenerationFunctionName) continue;

                var trigger = method.GetHttpTrigger();
                if (trigger != null)
                {
                    var responses = responseParser.Parse(method);
                    var path = new Path(trigger.GetRouteOrDefault());

                    //TODO: Process Parameters

                    foreach (var httpVerb in trigger.Methods)
                    {
                        var operation = operationParser.Parse(httpVerb, functionName);
                        operation.AddResponses(responses);
                        path.AddOperation(operation);
                    }

                    yield return path;

                }
            }
        }
    }
}
