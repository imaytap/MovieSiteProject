using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Dtos;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface IUserService : IServiceRepository<User, DeleteRequest, Guid>
    {
        IDataResult<List<User>> GetByStatus(bool status);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(Guid userId);
        IDataResult<List<UserOperationClaimDetails>> GetClaimsWithDetails(Guid userId);
        IDataResult<List<OperationClaim>> GetOtherClaims(Guid userId);
    }
}
