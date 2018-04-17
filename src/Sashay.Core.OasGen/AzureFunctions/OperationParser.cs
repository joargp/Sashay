using Sashay.Core.Oas.Schema._2._0;

namespace Sashay.Core.OasGen.AzureFunctions
{
    public class OperationParser : IOperationParser
    {
        private const string JsonFormat = "application/json";
        
        public Operation Parse(string httpMethod, string functionName)
        {
            var operation = new Operation(httpMethod)
            {
                OperationId = $"{httpMethod}{functionName}"
            };
            operation.AddOutputFormat(JsonFormat);

            return operation;
        }
    }
}
