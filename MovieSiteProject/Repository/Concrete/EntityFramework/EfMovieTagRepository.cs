using MovieSiteProject.Core.Repository.EntityFramework;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;

namespace MovieSiteProject.Repository.Concrete.EntityFramework
{
    public class EfMovieTagRepository : EfEntityRepositoryBase<MovieTag>, IMovieTagRepository
    {
    }
}
