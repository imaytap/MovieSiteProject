using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface IUserOperationClaimService : IServiceRepository<UserOperationClaim, DeleteRequest, Guid>
    {

    }
}
