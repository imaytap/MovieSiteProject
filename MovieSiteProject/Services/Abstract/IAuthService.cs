using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Core.Utilities.Security.Jwt;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> RegisterForAdmin(UserRegisterForAdminRequest userRegisterRequest);
        IDataResult<AccessToken> Register(UserRegisterRequest userRegisterRequest);
        IDataResult<AccessToken> Login(UserLoginRequest userLoginRequest);
        IDataResult<AccessToken> ChangePassword(UserChangePasswordRequest userChangePasswordRequest);
        IDataResult<AccessToken> UpdateUser(UserUpdateRequest userUpdateRequest);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<AccessToken> RefreshToken();
    }
}
