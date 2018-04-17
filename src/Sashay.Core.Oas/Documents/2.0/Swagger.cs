using System.Collections.Generic;
using System.Linq;
using Sashay.Core.Oas.Schema._2._0;

namespace Sashay.Core.Oas.Documents._2._0
{
    public class Swagger2
    {
        private readonly List<string> schemes;
        private readonly List<Path> paths;
        
        public Swagger2()
        {
            schemes = new List<string>();
            paths = new List<Path>();
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

        public IReadOnlyDictionary<string, Path> Paths => paths.ToDictionary(path => path.Route, el => el);

        public void AddPath(Path path)
        {
            paths.Add(path);
        }
    }
}
