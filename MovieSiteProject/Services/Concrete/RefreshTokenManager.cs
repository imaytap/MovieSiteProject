using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class RefreshTokenManager : AbstractServiceBase, IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenDal;

        public RefreshTokenManager(IRefreshTokenRepository refreshTokenDal)
        {
            _refreshTokenDal = refreshTokenDal;
        }

        public IDataResult<RefreshToken> Add(RefreshToken entity)
        {
            entity.CreatedDate = DateTime.Now;
            _refreshTokenDal.Add(entity);
            return new SuccessDataResult<RefreshToken>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            var entityToDelete = GetById(entity.Id).Data;
            _refreshTokenDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<RefreshToken>> GetAll()
        {
            return new SuccessDataResult<List<RefreshToken>>(_refreshTokenDal.GetAll());
        }

        public IDataResult<RefreshToken> GetByClientId(string clientId)
        {
            return new SuccessDataResult<RefreshToken>(_refreshTokenDal.Get(r => r.ClientId == clientId));
        }

        public IDataResult<RefreshToken> GetById(Guid id)
        {
            return new SuccessDataResult<RefreshToken>(_refreshTokenDal.Get(r => r.Id == id));
        }

        public IDataResult<RefreshToken> GetByRefreshToken(string refreshToken)
        {
            return new SuccessDataResult<RefreshToken>(_refreshTokenDal.Get(r => r.RefreshTokenValue == refreshToken));
        }

        public IDataResult<RefreshToken> GetByTokenAndRefreshTokenAndClientIdAndClientName(string token, string refreshToken, string clientId, string clientName)
        {
            return new SuccessDataResult<RefreshToken>(_refreshTokenDal.Get(r => r.TokenValue == token && r.RefreshTokenValue == refreshToken && r.ClientId == clientId && r.ClientName == clientName));
        }

        public IDataResult<List<RefreshToken>> GetByUserId(Guid userId)
        {
            return new SuccessDataResult<List<RefreshToken>>(_refreshTokenDal.GetAll(r => r.UserId == userId));
        }

        public IDataResult<RefreshToken> Update(RefreshToken entity)
        {
            _refreshTokenDal.Update(entity);
            return new SuccessDataResult<RefreshToken>(entity);
        }
    }
}
