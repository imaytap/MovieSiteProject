using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        public Guid XUserId { get; set; }
        public Guid MovieId { get; set; }
        public string Description { get; set; }

        public virtual XUser? XUser { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
