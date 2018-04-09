using Sashay.Core.Oas.Schema._2._0;

namespace Sashay.Core.Oas.Documents._2._0
{
    public class Swagger2
    {
        public string Swagger => "2.0";
        
        public Info Info { get; set; }

        public string Host { get; set; }
        
        public string BasePath { get; set; }

    }
}
