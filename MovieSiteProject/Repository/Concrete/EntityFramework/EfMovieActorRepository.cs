using MovieSiteProject.Core.Repository.EntityFramework;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;

namespace MovieSiteProject.Repository.Concrete.EntityFramework
{
    public class EfMovieActorRepository : EfEntityRepositoryBase<MovieActor>, IMovieActorRepository
    {
    }
}
