using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Dtos
{
    public class TranslateDetails : IDto
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Guid TranslateKeyId { get; set; }
        public string Value { get; set; }
        public string Language { get; set; }
        public string TranslateKey { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
