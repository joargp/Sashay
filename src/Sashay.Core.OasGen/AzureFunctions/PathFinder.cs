using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Sashay.Core.Oas.Extensions;
using Sashay.Core.Oas.Schema._2._0;
using Sashay.Core.OasGen.AzureFunctions.Extensions;

namespace Sashay.Core.OasGen
{
    public class PathFinder
    {
        public TraceWriter logger { get; set; }


        public PathFinder(string generationFunctionName = null)
        {
            GenerationFunctionName = generationFunctionName ?? "Swagger";
        }

        public string GenerationFunctionName { get;  }

        public IEnumerable<Path> FindPaths(Assembly assembly)
        {
            var functionMethods = assembly.GetTypes()
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
                        var operation = new Operation(httpVerb);
                        path.AddOperation(operation);
                    }

                    yield return path;

                }
            }
        }
    }
}
