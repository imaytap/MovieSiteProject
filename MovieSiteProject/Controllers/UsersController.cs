using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Aspects.System.Authorization;
using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class UsersController : ServiceController<User, DeleteRequest, Guid>
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByStatus(bool status)
        {
            var result = _userService.GetByStatus(status);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetUserClaims(Guid userId)
        {
            var result = _userService.GetClaimsWithDetails(userId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetOtherClaims(Guid userId)
        {
            var result = _userService.GetOtherClaims(userId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
