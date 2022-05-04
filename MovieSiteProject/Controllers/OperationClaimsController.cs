using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class OperationClaimsController : ServiceController<OperationClaim, DeleteRequest, Guid>
    {
        private readonly IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService) : base(operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByName(string name)
        {
            var result = _operationClaimService.GetByName(name);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
