using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class MoviesController : ServiceController<Movie, MovieAddRequest, DeleteRequest, Guid>
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService) : base(movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("[action]")]
        public override Task<IActionResult> Add([FromForm] MovieAddRequest entity)
        {
            return base.Add(entity);
        }
    }
}
