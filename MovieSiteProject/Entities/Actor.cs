using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Entities
{
    public class Actor : BaseEntity<Guid>
    {
        public Guid XUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual XUser? XUser { get; set; }
    }
}
