using System;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class Path
    {
        public Path(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
                throw new ArgumentException("Value cannot be null or empty.", nameof(route));
            if (route[0] != '/')
            {
                route = $"/{route}";
            }
            
            if(route.EndsWith("/"))
            {
                route = route.TrimEnd('/');
            }
            
            Route = route;
        }

        public string Route { get; }
       // public IReadOnlyDictionaryDictionary<string, string> Operations { get; }
        
        //TODO: Add Operation
    }
}
