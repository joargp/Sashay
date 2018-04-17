using Sashay.Core.Oas.Schema._2._0;
using Sashay.Core.OasGen.AzureFunctions.Attributes;

namespace Sashay.Core.OasGen.AzureFunctions.Parsers
{
    public interface IResponseParser
    {
        Response Parse(ProducesResponseAttribute attribute);
    }
}
