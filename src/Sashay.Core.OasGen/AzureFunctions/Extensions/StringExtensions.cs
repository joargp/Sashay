using System;
using System.Text.RegularExpressions;

namespace Sashay.Core.OasGen.AzureFunctions.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsParameter(this string route, string parameterName)
        {
            if (route == null) throw new ArgumentNullException(nameof(route));
            if (parameterName == null) throw new ArgumentNullException(nameof(parameterName));

            var pattern = ".*{" + parameterName.Trim() + @"((:){1}(\w+))?}";

            return Regex.IsMatch(route, pattern, RegexOptions.IgnoreCase);
        }
    }
}