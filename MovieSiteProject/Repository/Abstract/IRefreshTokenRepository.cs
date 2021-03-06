using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Repository;

namespace MovieSiteProject.Repository.Abstract
{
    public interface IRefreshTokenRepository : IEntityRepository<RefreshToken>
    {
    }
}
