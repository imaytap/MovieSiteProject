using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Core.Entities.Concrete
{
    public class Language : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
