using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class ActorsController : ServiceController<Actor, DeleteRequest, Guid>
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService) : base(actorService)
        {
            _actorService = actorService;
        }
    }
}
