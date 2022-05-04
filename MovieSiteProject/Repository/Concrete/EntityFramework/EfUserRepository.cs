using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Repository.EntityFramework;
using MovieSiteProject.Core.Utilities.IoC;
using MovieSiteProject.Dtos;
using MovieSiteProject.Repository.Abstract;

namespace MovieSiteProject.Repository.Concrete.EntityFramework
{
    public class EfUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public List<OperationClaim> GetClaims(Guid userId)
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == userId
                             select operationClaim;

                return result.ToList();
            }
        }
        public List<UserOperationClaimDetails> GetClaimsWithDetails(Guid userId)
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                var result = from operationClaim in context.OperationClaims
                             from user in context.Users
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == userId
                             where user.Id == userId
                             select new UserOperationClaimDetails()
                             {
                                 Id = userOperationClaim.Id,
                                 UserId = userId,
                                 OperationClaimId = operationClaim.Id,
                                 OperationClaimName = operationClaim.Name,
                                 Email = user.Email
                             };

                return result.ToList();
            }
        }
    }
}
