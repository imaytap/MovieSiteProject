using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class CategoriesController : ServiceController<Category, DeleteRequest, Guid>
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) : base(categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
