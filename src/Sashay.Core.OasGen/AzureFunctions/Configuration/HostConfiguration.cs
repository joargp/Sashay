namespace Sashay.Core.OasGen.AzureFunctions.Configuration
{
    public sealed class HostConfiguration
    {
        public HostConfiguration()
        {
            Http = new HttpSettings();
        }

        public HttpSettings Http { get; set; }
    }
}
