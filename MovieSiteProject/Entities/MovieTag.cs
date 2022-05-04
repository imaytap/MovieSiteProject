using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Entities
{
    public class MovieTag : BaseEntity<Guid>
    {
        public Guid MovieId { get; set; }
        public Guid TagId { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Tag? Tag { get; set; }
    }
}
