using System;

namespace Sashay.Core.Oas.Schema._2._0
{
    public class DuplicateOperationException : Exception
    {
        private const string ErrorMessageFormat = "Operations must have unique HttpMethods. Path already has operation using '{0}' registered.";
        
        public DuplicateOperationException(string httpMethod)
        : base(ErrorMessageGenerateErrorMessage(httpMethod))
        {
            
        }
        

        public DuplicateOperationException(string httpMethod, Exception inner)
            : base(ErrorMessageGenerateErrorMessage(httpMethod), inner)
        {
        }

        private static string ErrorMessageGenerateErrorMessage(string httpMethod)
        {
            return string.Format(ErrorMessageFormat, httpMethod.ToUpperInvariant());
        } 
    }
}
