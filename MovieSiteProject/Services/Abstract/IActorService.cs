using MovieSiteProject.Core.Services;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface IActorService : IServiceRepository<Actor, DeleteRequest, Guid>
    {
    }
}
