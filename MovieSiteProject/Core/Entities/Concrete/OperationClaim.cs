using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Core.Entities.Concrete
{
    public class OperationClaim : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}