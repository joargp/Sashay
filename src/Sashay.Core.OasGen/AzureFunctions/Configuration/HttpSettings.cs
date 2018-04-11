namespace Sashay.Core.OasGen.AzureFunctions.Configuration
{
    public sealed class HttpSettings
    {
        public HttpSettings()
        {
            RoutePrefix = string.Empty;
        }

        public string RoutePrefix { get; set; }
    }
}
