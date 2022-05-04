using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Core.Entities.Concrete
{
    public class Translate : BaseEntity<Guid>
    {
        public Guid LanguageId { get; set; }
        public Guid TranslateKeyId { get; set; }
        public string Value { get; set; }

        public virtual Language? Language { get; set; }
        public virtual TranslateKey? TranslateKey { get; set; }
    }
}
