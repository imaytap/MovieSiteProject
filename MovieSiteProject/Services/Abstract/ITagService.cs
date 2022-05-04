using MovieSiteProject.Core.Services;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface ITagService : IServiceRepository<Tag, DeleteRequest, Guid>
    {
    }
}
