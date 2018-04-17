using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sashay.Core.Oas.Extensions;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class Path : IReadOnlyDictionary<string, Operation>
    {
        private readonly Dictionary<string, Operation> operations;
        
        public Path(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
                throw new ArgumentException("Value cannot be null or empty.", nameof(route));
            
            Route = route.AsPath();

            operations = new Dictionary<string, Operation>();
        }

        [JsonIgnore]
        public string Route { get; }
        
      
        public void AddOperation(Operation operation)
        {
            if (operation == null) return;
            if (operations.ContainsKey(operation.HttpMethod))
            {
                throw new DuplicateOperationException(operation.HttpMethod);
            }
            
            operations.Add(operation.HttpMethod, operation);

        }

        public IEnumerator<KeyValuePair<string, Operation>> GetEnumerator()
        {
            return operations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => operations.Count;
        public bool ContainsKey(string key)
        {
            return operations.ContainsKey(key);
        }

        public bool TryGetValue(string key, out Operation value)
        {
            return operations.TryGetValue(key, out value);
        }

        public Operation this[string key] => operations[key];

        public IEnumerable<string> Keys => operations.Keys;
        public IEnumerable<Operation> Values => operations.Values;
    }
}
