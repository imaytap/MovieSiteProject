using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class TagsController : ServiceController<Tag, DeleteRequest, Guid>
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService) : base(tagService)
        {
            _tagService = tagService;
        }
    }
}
