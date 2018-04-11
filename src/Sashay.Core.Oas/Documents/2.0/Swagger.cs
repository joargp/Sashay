using System.Collections;
using System.Collections.Generic;
using System.Data;
using Sashay.Core.Oas.Schema._2._0;

namespace Sashay.Core.Oas.Documents._2._0
{
    public class Swagger2
    {
        private readonly List<string> schemes;
        
        public Swagger2()
        {
            schemes = new List<string>();
        }

        public string Swagger => "2.0";
        
        public Info Info { get; set; }

        public string Host { get; set; }
        
        public string BasePath { get; set; }

        public IEnumerable<string> Schemes => schemes;

        public void AddScheme(string scheme)
        {
            schemes.Add(scheme.ToLowerInvariant());
        }
    }
}
