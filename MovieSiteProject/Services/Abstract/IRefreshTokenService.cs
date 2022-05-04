using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface IRefreshTokenService : IServiceRepository<RefreshToken, DeleteRequest, Guid>
    {
        IDataResult<RefreshToken> GetByRefreshToken(string refreshToken);
        IDataResult<RefreshToken> GetByTokenAndRefreshTokenAndClientIdAndClientName(string token, string refreshToken, string clientId, string clientName);
        IDataResult<RefreshToken> GetByClientId(string clientId);
        IDataResult<List<RefreshToken>> GetByUserId(Guid userId);
    }
}
