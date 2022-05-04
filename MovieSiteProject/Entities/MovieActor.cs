using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Entities
{
    public class MovieActor : BaseEntity<Guid>
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Actor? Actor { get; set; }
    }
}
