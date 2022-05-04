namespace MovieSiteProject.Core.Utilities.Contexts.Translate
{
    public class TranslateContext : ITranslateContext
    {
        public Dictionary<string, string> Translates { get; set; } = new Dictionary<string, string>();
    }
}
