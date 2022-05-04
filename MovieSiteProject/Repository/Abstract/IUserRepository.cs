using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Repository;
using MovieSiteProject.Dtos;

namespace MovieSiteProject.Repository.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(Guid userId);
        List<UserOperationClaimDetails> GetClaimsWithDetails(Guid userId);
    }
}
