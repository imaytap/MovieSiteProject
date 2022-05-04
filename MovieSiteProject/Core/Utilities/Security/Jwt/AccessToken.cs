using MovieSiteProject.Core.Entities.Concrete;

namespace MovieSiteProject.Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}