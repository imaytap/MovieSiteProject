using MovieSiteProject.Core.Services;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface IMovieService : IServiceRepository<Movie, MovieAddRequest, DeleteRequest, Guid>
    {
    }
}
