using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface IOperationClaimService : IServiceRepository<OperationClaim, DeleteRequest, Guid>
    {
        IDataResult<OperationClaim> GetByName(string name);
    }
}
