using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class MovieActorsController : ServiceController<MovieActor, DeleteRequest, Guid>
    {
        private readonly IMovieActorService _movieActorService;

        public MovieActorsController(IMovieActorService movieActorService) : base(movieActorService)
        {
            _movieActorService = movieActorService;
        }
    }
}
