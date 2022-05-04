using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Services.Abstract;
using System.Security.Cryptography;

namespace MovieSiteProject.Helpers
{
    public class RefreshTokenHelper : AbstractServiceBase, IRefreshTokenHelper
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private string _token;
        private string _refreshToken;
        private string _clientId;
        private string _clientName;

        public RefreshTokenHelper(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }


        public string CreateRefreshToken()
        {
            var number = new byte[32];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        public void CreateDifferentRefreshToken(RefreshToken refreshToken)
        {
            while (_refreshTokenService.GetByRefreshToken(refreshToken.RefreshTokenValue).Data != null)
                refreshToken.RefreshTokenValue = CreateRefreshToken();
        }

        public RefreshToken CreateNewRefreshToken(User user, string tokenValue)
        {
            _clientId = HttpContextAccessor.HttpContext.Request.Headers["ClientId"];
            _clientName = HttpContextAccessor.HttpContext.Request.Headers["ClientName"];

            if (!Control(_clientId))
            {
                _clientId = Guid.NewGuid().ToString();
                while (_refreshTokenService.GetByClientId(_clientId).Data != null) _clientId = Guid.NewGuid().ToString();
            }

            var newRefreshToken = new RefreshToken
            {
                UserId = user.Id,
                ClientName = _clientName,
                ClientId = _clientId,
                RefreshTokenValue = CreateRefreshToken(),
                TokenValue = tokenValue,
                User = user,
            };

            CreateDifferentRefreshToken(newRefreshToken);
            var oldRefreshToken = _refreshTokenService.GetByClientId(_clientId).Data;

            if (oldRefreshToken != null)
            {
                newRefreshToken.Id = Guid.Parse(oldRefreshToken.Id.ToString());
                _refreshTokenService.Update(newRefreshToken);
            }
            else
            {
                _refreshTokenService.Add(newRefreshToken);
            }

            return newRefreshToken;
        }

        public RefreshToken UpdateOldRefreshToken(string tokenValue)
        {
            _token = HttpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (Control(_token))
            {
                var tokens = _token.Split(" ");
                if (tokens.Length > 1)
                    _token = tokens[1];
            }

            _clientId = HttpContextAccessor.HttpContext.Request.Headers["ClientId"];
            _clientName = HttpContextAccessor.HttpContext.Request.Headers["ClientName"];
            _refreshToken = HttpContextAccessor.HttpContext.Request.Headers["RefreshToken"];

            if (!Control(_token, _clientId, _clientName, _refreshToken))
                return null;

            var newRefreshToken = _refreshTokenService.GetByTokenAndRefreshTokenAndClientIdAndClientName(_token, _refreshToken, _clientId, _clientName).Data;
            if (newRefreshToken != null)
            {
                CreateDifferentRefreshToken(newRefreshToken);
                newRefreshToken.TokenValue = tokenValue;
                _refreshTokenService.Update(newRefreshToken);
                return newRefreshToken;
            }

            return null;
        }

        public bool Control(params string[] args)
        {
            foreach (string arg in args)
            {
                if (arg == null || arg == "" || arg == "null")
                    return false;
            }

            return true;
        }
    }
}
