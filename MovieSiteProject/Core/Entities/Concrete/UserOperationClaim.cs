using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }

        public virtual User? User { get; set; }
        public virtual OperationClaim? OperationClaim { get; set; }
    }
}