using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class UserOperationClaimsController : ServiceController<UserOperationClaim, DeleteRequest, Guid>
    {
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService) : base(userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }
    }
}
