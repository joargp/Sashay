using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Sashay.Core.Oas.Extensions;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class Path
    {
        private readonly List<Operation> operations;
        
        public Path(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
                throw new ArgumentException("Value cannot be null or empty.", nameof(route));
            
            Route = route.AsPath();

            operations = new List<Operation>();
        }

        [JsonIgnore]
        public string Route { get; }
        
        public IReadOnlyDictionary<string, Operation> Operations => operations.ToDictionary(op => op.HttpMethod, el => el);

        public void AddOperation(Operation operation)
        {
            if (operation == null) return;
            if (operations.Any(op => op.HttpMethod.Equals(operation.HttpMethod)))
            {
                throw new DuplicateOperationException(operation.HttpMethod);
            }
            operations.Add(operation);

        }
    }
}
