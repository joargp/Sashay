using System;
using System.Collections.Generic;
using System.Linq;
using Sashay.Core.Oas.Extensions;
using Sashay.Core.Oas.Schema.Exceptions;

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

        public string Route { get; }
        
        public IReadOnlyDictionary<string, Operation> Operations => operations.ToDictionary(op => op.HttpMethod, el => el);

        public void AddOperation(Operation operation)
        {
            if (operations.Any(op => op.HttpMethod.Equals(operation.HttpMethod)))
            {
                throw new DuplicateOperationExeception(operation.HttpMethod);
            }
            operations.Add(operation);
        }
    }
}
