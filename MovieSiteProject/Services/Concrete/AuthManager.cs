using MovieSiteProject.Core.Aspects.Autofac.Transaction;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Core.Utilities.Security.Hashing;
using MovieSiteProject.Core.Utilities.Security.Jwt;
using MovieSiteProject.Helpers;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class AuthManager : AbstractServiceBase, IAuthService
    {
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IRefreshTokenHelper _refreshTokenHelper;

        public AuthManager(IUserService userService, IRefreshTokenHelper refreshTokenHelper, IRefreshTokenService refreshTokenService)
        {
            _userService = userService;
            _refreshTokenHelper = refreshTokenHelper;
            _refreshTokenService = refreshTokenService;
        }

        // [SecuredOperation("Admin")]
        [TransactionScopeAspect]
        public IDataResult<AccessToken> ChangePassword(UserChangePasswordRequest userChangePasswordRequest)
        {
            var user = _userService.GetById(userChangePasswordRequest.Id).Data;
            if (user == null)
                return new ErrorDataResult<AccessToken>("User not found");

            HashingHelper.CreatePasswordHash(userChangePasswordRequest.NewPassword, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userService.Update(user);

            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, "Kullanıcının şifresi değiştirildi");
        }

        [TransactionScopeAspect]
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetClaims(user.Id).Data;
            var accessToken = UserTokenHelper.CreateToken(user, roles);

            string refreshToken = HttpContextAccessor.HttpContext.Request.Headers["RefreshToken"];
            if (_refreshTokenHelper.Control(refreshToken) && _refreshTokenService.GetByRefreshToken(refreshToken).Data != null)
                accessToken.RefreshToken = _refreshTokenHelper.UpdateOldRefreshToken(accessToken.Token);
            else
                accessToken.RefreshToken = _refreshTokenHelper.CreateNewRefreshToken(user, accessToken.Token);

            if (accessToken.RefreshToken == null)
                return new ErrorDataResult<AccessToken>();

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        [TransactionScopeAspect]
        public IDataResult<AccessToken> Login(UserLoginRequest userLoginRequest)
        {
            var result = BusinessRules.Run(CheckIfUserIsNotExists(userLoginRequest));

            if (!result.Success)
                return new ErrorDataResult<AccessToken>(result.Message);

            var user = _userService.GetByEmail(userLoginRequest.Email).Data;
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, "Giriş Başarılı");
        }

        [TransactionScopeAspect]
        public IDataResult<AccessToken> RefreshToken()
        {
            string refreshToken = HttpContextAccessor.HttpContext.Request.Headers["RefreshToken"];

            var newRefreshToken = _refreshTokenService.GetByRefreshToken(refreshToken).Data;
            if (newRefreshToken != null)
            {
                var user = _userService.GetById(newRefreshToken.UserId).Data;
                return RefreshTokenControl(user);
            }

            RequestUserService.RequestUser = null;
            return new ErrorDataResult<AccessToken>();
        }

        [TransactionScopeAspect]
        public IDataResult<AccessToken> Register(UserRegisterRequest userRegisterRequest)
        {
            var result = BusinessRules.Run(CheckIfUserIsAlreadyExists(userRegisterRequest.Email));

            if (!result.Success)
                return new ErrorDataResult<AccessToken>(result.Message);

            HashingHelper.CreatePasswordHash(userRegisterRequest.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Email = userRegisterRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, "Kayıt Başarılı");
        }

        public IDataResult<AccessToken> RegisterForAdmin(UserRegisterForAdminRequest userRegisterRequest)
        {
            var result = BusinessRules.Run(CheckIfUserIsAlreadyExists(userRegisterRequest.Email));

            if (!result.Success)
                return new ErrorDataResult<AccessToken>(result.Message);

            HashingHelper.CreatePasswordHash(userRegisterRequest.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Email = userRegisterRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userRegisterRequest.Status
            };

            _userService.Add(user);

            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, "Kayıt Başarılı");
        }

        public IDataResult<AccessToken> UpdateUser(UserUpdateRequest userUpdateRequest)
        {
            var user = _userService.GetById(userUpdateRequest.Id).Data;
            if (user == null)
                return new ErrorDataResult<AccessToken>();

            //user.FirstName = userUpdateRequest.FirstName;
            //user.LastName = userUpdateRequest.LastName;
            user.Email = userUpdateRequest.Email;
            user.Status = userUpdateRequest.Status;
            _userService.Update(user);

            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, "Kullanıcı güncellendi");
        }

        private IResult CheckIfUserIsAlreadyExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
                return new ErrorResult("Kullanıcı Mevcut");

            return new SuccessResult();
        }

        // Update before deploy
        private IResult CheckIfUserIsNotExists(UserLoginRequest userLoginRequest)
        {
            var user = _userService.GetByEmail(userLoginRequest.Email).Data;
            if (user == null)
                return new ErrorResult("Kullanıcı Mevcut Değil");

            if (user != null)
            {
                if (!HashingHelper.VerifyPasswordHash(userLoginRequest.Password, user.PasswordHash, user.PasswordSalt))
                    return new ErrorResult("Şifre Hatalı");
            }

            return new SuccessResult();
        }

        private IDataResult<AccessToken> RefreshTokenControl(User user)
        {
            var result = CreateAccessToken(user);
            if (result.Success) return result;

            RequestUserService.RequestUser = null;
            return result;
        }
    }
}
