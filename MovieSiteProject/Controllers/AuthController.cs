using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class AuthController : ArtController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public IActionResult ChangePassword(UserChangePasswordRequest userChangePasswordRequest)
        {
            var result = _authService.ChangePassword(userChangePasswordRequest);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult UpdateUser(UserUpdateRequest userUpdateRequest)
        {
            var result = _authService.UpdateUser(userUpdateRequest);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult Login(UserLoginRequest userLoginRequest)
        {
            var result = _authService.Login(userLoginRequest);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult Register(UserRegisterRequest userRegisterRequest)
        {
            var result = _authService.Register(userRegisterRequest);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult RegisterForAdmin(UserRegisterForAdminRequest userRegisterRequest)
        {
            var result = _authService.RegisterForAdmin(userRegisterRequest);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult RefreshToken()
        {
            var result = _authService.RefreshToken();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
