using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class MovieTagsController : ServiceController<MovieTag, DeleteRequest, Guid>
    {
        private readonly IMovieTagService _movieTagService;

        public MovieTagsController(IMovieTagService movieTagService) : base(movieTagService)
        {
            _movieTagService = movieTagService;
        }
    }
}
