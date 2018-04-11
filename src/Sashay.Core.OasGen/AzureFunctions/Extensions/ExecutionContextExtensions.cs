using System.IO;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using Sashay.Core.OasGen.AzureFunctions.Configuration;

namespace Sashay.Core.OasGen.AzureFunctions.Extensions
{
    public static class ExecutionContextExtensions
    {
        public const string HostFileName = "host.json";
        
        public static HostConfiguration GetHostConfiguration(this ExecutionContext context)
        {
            if (context == null || string.IsNullOrEmpty(context.FunctionAppDirectory))
            {
                return new HostConfiguration();
            }

            var hostFilePath = Path.Combine(context.FunctionAppDirectory, HostFileName);
            if (!File.Exists(hostFilePath))
            {
                return new HostConfiguration();
            }

            var contents = File.ReadAllText(hostFilePath);
            return JsonConvert.DeserializeObject<HostConfiguration>(contents);
        }
    }
}
