namespace Sashay.Core.Oas.Extensions
{
    public static class StringExtensions
    {
        public static string AsPath(this string path)
        {
            //Currently assuming that reasonable values are going to appear in here
            //we could probably tighten this up a little bit with some better input checking.
            if(path.Equals("/"))
            {
                return path;
            }
            path = path.TrimEnd('/');
            if (!path[0].Equals('/'))
            {
                path = $"/{path}";
            }
            
            return path.ToLower();
        }
    }
}
