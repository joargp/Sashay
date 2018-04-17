using Sashay.Core.Oas.Schema._2._0;

namespace Sashay.Core.OasGen.AzureFunctions.Parsers
{
    public interface IOperationParser
    {
        Operation Parse(string httpMethod, string functionName);
    }
}
