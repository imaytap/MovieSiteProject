using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Services.Requests
{
    public class MovieAddRequest : IRequest
    {
        public Guid XUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public IFormFile Video { get; set; }
        public IFormFile Image { get; set; }
    }
}
