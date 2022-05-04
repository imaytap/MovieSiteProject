using MovieSiteProject.Core.Entities.Concrete;

namespace MovieSiteProject.Helpers
{
    public interface IRefreshTokenHelper
    {
        string CreateRefreshToken();
        RefreshToken CreateNewRefreshToken(User user, string tokenValue);
        RefreshToken UpdateOldRefreshToken(string tokenValue);
        void CreateDifferentRefreshToken(RefreshToken refreshToken);
        bool Control(params string[] args);
    }
}
