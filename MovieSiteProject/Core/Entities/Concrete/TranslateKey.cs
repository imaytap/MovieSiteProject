using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Core.Entities.Concrete
{
    public class TranslateKey : BaseEntity<Guid>
    {
        public string Key { get; set; }
    }
}
