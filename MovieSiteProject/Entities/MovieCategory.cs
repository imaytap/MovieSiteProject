using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Entities
{
    public class MovieCategory : BaseEntity<Guid>
    {
        public Guid MovieId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Category? Category { get; set; }
    }
}
