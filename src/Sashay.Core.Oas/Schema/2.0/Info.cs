using System.ComponentModel;


namespace Sashay.Core.Oas.Schema._2._0
{
    public class Info
    {
        private const string DefaultTitle = "Sample API";
        private const string DefaultVersion = "1.0.0";
        private const string DefaultDescription = "";
        
        
        public Info(string description, string version = DefaultVersion, string title = DefaultTitle)
        {
            Title = title;
            Version = version;
            Description = description;
        }


        [DefaultValue(DefaultTitle)]
        public string Title { get; set; }
        
        [DefaultValue(DefaultVersion)]
        public string Version { get; set; }
        
        [DefaultValue(DefaultDescription)]
        public string Description { get; set; }
    }


}
