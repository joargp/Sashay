using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Sashay.Core.Oas.Extensions;
using Sashay.Core.Oas.Schema._2._0;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using System;

namespace Sashay.Core.OasGen
{
    public class PathFinder
    {
        private readonly IOperationParser operationParser;
        public TraceWriter logger { get; set; }


        public PathFinder(IOperationParser operationParser, string generationFunctionName = null)
        {
            this.operationParser = operationParser;
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
                .Where(m => m.GetCustomAttributes(typeof(FunctionNameAttribute), false).Any())
                .ToArray();
            
            foreach (var method in functionMethods)
            {
                var funcNameAttribute = method.GetCustomAttribute<FunctionNameAttribute>();

                if (funcNameAttribute.Name == GenerationFunctionName) continue;

                var trigger = method.GetHttpTrigger();
                if (trigger != null)
                {
                    var route = trigger.Route != null
                        ? trigger.Route.AsPath()
                        : "/";

                    var path = new Path(route);


                    foreach (var httpVerb in trigger.Methods)
                    {
                        var operation = operationParser.Parse(httpVerb, funcNameAttribute.Name);
                        path.AddOperation(operation);
                    }

                    yield return path;

                }
            }
        }
    }
}
