using System;

namespace Sashay.Core.Oas.Schema.Exceptions
{
    public class DuplicateOperationExeception : Exception
    {
        private const string errorMessageFormat = "Operations must have unique HttpMethods. Path already has operation using '{0}' registered.";
        
        public DuplicateOperationExeception(string httpMethod)
        : base(ErrorMessageGenerateErrorMessage(httpMethod))
        {
            
        }
        

        public DuplicateOperationExeception(string httpMethod, Exception inner)
            : base(ErrorMessageGenerateErrorMessage(httpMethod), inner)
        {
        }

        private static string ErrorMessageGenerateErrorMessage(string httpMethod)
        {
            return string.Format(errorMessageFormat, httpMethod.ToUpperInvariant());
        } 
    }
}
