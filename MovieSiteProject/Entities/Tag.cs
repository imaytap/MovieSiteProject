using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Entities
{
    public class Tag : BaseEntity<Guid>
    {
        public Guid XUserId { get; set; }
        public string Name { get; set; }

        public virtual XUser? XUser { get; set; }
    }
}
