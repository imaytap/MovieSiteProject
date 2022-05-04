using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class MovieCategoriesController : ServiceController<MovieCategory, DeleteRequest, Guid>
    {
        private readonly IMovieCategoryService _movieCategoryService;

        public MovieCategoriesController(IMovieCategoryService movieCategoryService) : base(movieCategoryService)
        {
            _movieCategoryService = movieCategoryService;
        }
    }
}
