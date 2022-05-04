using MovieSiteProject.Core.Repository;
using MovieSiteProject.Entities;

namespace MovieSiteProject.Repository.Abstract
{
    public interface IMovieRepository : IEntityRepository<Movie>
    {
    }
}
